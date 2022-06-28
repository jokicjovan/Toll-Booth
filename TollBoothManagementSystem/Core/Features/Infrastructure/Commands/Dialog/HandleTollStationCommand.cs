using System;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using System.Windows;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.GUI.Utility.Dialog;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands.Dialog
{
    public class HandleTollStationCommand : CommandBase
    {
        private readonly ITollStationService _tollStationService;
        private readonly ISectionService _sectionService;
        private readonly ISectionInfoService _sectionInfoService;
        private readonly IRoadTollPriceService _roadTollPriceService;
        private readonly IPriceListService _priceListService;
        private readonly TollStationsViewModel _tollStationsVM;
        private readonly HandleTollStationViewModel _handleTollStationVM;

        private Guid _tollStationId;

        public HandleTollStationCommand(ITollStationService tollStationService, ISectionService sectionService,
            ISectionInfoService sectionInfoService, IRoadTollPriceService roadTollPriceService,
            IPriceListService priceListService,
            TollStationsViewModel tollStationsVM,
            HandleTollStationViewModel handleTollStationVM, Guid tollStationId)
        {
            _tollStationService = tollStationService;
            _sectionService = sectionService;
            _sectionInfoService = sectionInfoService;
            _roadTollPriceService = roadTollPriceService;
            _priceListService = priceListService;
            _tollStationsVM = tollStationsVM;
            _handleTollStationVM = handleTollStationVM;
            _tollStationId = tollStationId;
            _handleTollStationVM.PropertyChanged += _handleTollStationVM_PropertyChanged;
        }

        private void _handleTollStationVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HandleTollStationViewModel.CanExecute))
            {
                OnCanExecuteChange(sender, e);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _handleTollStationVM.CanExecute;
        }

        public override void Execute(object? parameter)
        {
            int.TryParse(_handleTollStationVM.OrderNumber, out int orderNumber);
            if (_tollStationId == Guid.Empty)
            {
                if (_sectionService.IsOrderNumberValid(orderNumber, _handleTollStationVM.SelectedSection.Id))
                {
                    HandleAction(parameter, AddStation);
                    MessageBox.Show("Toll station added successfully");
                }
                else
                {
                    _handleTollStationVM.OrderNumberError.ErrorMessage = "Order number is not valid";
                }
            }
            else
            {
                HandleAction(parameter, UpdateEmployee);
                MessageBox.Show("Toll station updated successfully");
            }
        }

        public void HandleAction(object parameter, Action action)
        {
            action();
            //_employeesVM.SearchEmployee();
            _handleTollStationVM.ResetFields();
            var dialog = (DialogWindow)parameter;
            dialog.DialogResult = true;
            dialog.Close();
        }

        public void AddStation()
        {
            // Add station
            int.TryParse(_handleTollStationVM.OrderNumber, out int orderNumber);
            var tollStation = new TollStation()
            {
                Name = _handleTollStationVM.StationName,
                Location = _handleTollStationVM.SelectedLocation,
                Boss = (Referent) _handleTollStationVM.SelectedReferent,
                TollBooths = new List<TollBooth>(),
                Employees = new List<Employee>(),
                OrderNumber = orderNumber
            };
            _tollStationService.Create(tollStation);

            // Update order numbers in section
            var section = _sectionService.Read(_handleTollStationVM.SelectedSection.Id);
            section.TollStations.Add(tollStation);
            _sectionService.ShiftTollStationOrderNumbers(orderNumber, section.Id);

            // Add section info
            int.TryParse(_handleTollStationVM.Distance, out int distance);
            var sectionInfo = new SectionInfo()
            {
                Section = section,
                TollStation = tollStation,
                Distance = distance
            };
            _sectionInfoService.Create(sectionInfo);

            // Add prices
            int.TryParse(_handleTollStationVM.Price, out int price);
            var priceList = _priceListService.GetActivePricelist(section);
            _roadTollPriceService.GeneratePrices(priceList, tollStation, price);
        }

        public void UpdateEmployee()
        {
            //var employeeToUpdate = _userService.Read(_employeeId);

            //employeeToUpdate.EmailAddress = _handleEmployeeVM.EmailAddress;
            //employeeToUpdate.Password = _handleEmployeeVM.Password;
            //employeeToUpdate.FirstName = _handleEmployeeVM.FirstName;
            //employeeToUpdate.LastName = _handleEmployeeVM.LastName;
            //employeeToUpdate.DateOfBirth = _handleEmployeeVM.DateOfBirth;
            //employeeToUpdate.Role = (Role)_handleEmployeeVM.ChosenRole;

            //_userService.Update(employeeToUpdate);
        }
    }
}
