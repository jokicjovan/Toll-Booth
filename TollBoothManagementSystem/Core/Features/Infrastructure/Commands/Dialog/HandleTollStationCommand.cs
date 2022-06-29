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
            if (! _sectionService.IsOrderNumberValid(orderNumber, _handleTollStationVM.SelectedSection.Id))
            {
                _handleTollStationVM.OrderNumberError.ErrorMessage = "Order number is not valid";
                return;
            }

            if (_tollStationId == Guid.Empty)
            {
                HandleAction(parameter, AddStation);
                MessageBox.Show("Toll station added successfully");
            }
            else
            {
                HandleAction(parameter, UpdateStation);
                MessageBox.Show("Toll station updated successfully");
            }
        }

        public void HandleAction(object parameter, Action action)
        {
            action();
            _tollStationsVM.Search();
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
            _sectionService.ShiftTollStationOrderNumbers(orderNumber, section.Id);
            section.TollStations.Add(tollStation);
            _sectionService.Update(section);

            // Add section info
            double.TryParse(_handleTollStationVM.Distance, out double distance);
            var sectionInfo = new SectionInfo()
            {
                Section = section,
                TollStation = tollStation,
                Distance = distance
            };
            _sectionInfoService.Create(sectionInfo);

            // Add prices
            double.TryParse(_handleTollStationVM.Price, out double price);
            var priceList = _priceListService.GetActivePricelist(section);
            _roadTollPriceService.GeneratePrices(priceList, tollStation, price);
        }

        public void UpdateStation()
        {

            int.TryParse(_handleTollStationVM.OrderNumber, out int orderNumber);
            double.TryParse(_handleTollStationVM.Price, out double price);
            double.TryParse(_handleTollStationVM.Distance, out double distance);
            var section = _sectionService.Read(_handleTollStationVM.SelectedSection.Id);
            var priceList = _priceListService.GetActivePricelist(section);

            if (section.Id == _sectionService.getSectionForTollStation(_handleTollStationVM.stationToUpdate.Id).Id)
            {
                if (price != _roadTollPriceService.GetBasePriceForTollStation(priceList.Id, _handleTollStationVM.stationToUpdate.Id))
                    _roadTollPriceService.UpdatePrices(priceList, _handleTollStationVM.stationToUpdate, price);


                // Update order numbers in section
                if (orderNumber != _handleTollStationVM.stationToUpdate.OrderNumber)
                {
                    _sectionService.ShiftTollStationOrderNumbersLeft(_handleTollStationVM.stationToUpdate.OrderNumber, section.Id);
                    _sectionService.ShiftTollStationOrderNumbers(orderNumber, section.Id);
                }

                // Update section info
                var newSectionInfo = _sectionInfoService.getSectionInfoForTollStation(_handleTollStationVM.stationToUpdate.Id); ;
                newSectionInfo.Distance = distance;
                _sectionInfoService.Update(newSectionInfo);
            }
            else
            {
                section.TollStations.Add(_handleTollStationVM.stationToUpdate);
                _roadTollPriceService.ClearPricesForTollStation(_handleTollStationVM.stationToUpdate.Id);
                _roadTollPriceService.GeneratePrices(priceList, _handleTollStationVM.stationToUpdate, price);
                _sectionService.ShiftTollStationOrderNumbers(orderNumber, section.Id);

                var newSectionInfo = new SectionInfo()
                {
                    TollStation = _handleTollStationVM.stationToUpdate,
                    Section = section,
                    Distance = distance
                };
                _sectionInfoService.Create(newSectionInfo);
            }

            // Update station
            _handleTollStationVM.stationToUpdate.Name = _handleTollStationVM.StationName;
            _handleTollStationVM.stationToUpdate.OrderNumber = orderNumber;
            _handleTollStationVM.stationToUpdate.Location = _handleTollStationVM.SelectedLocation;
            _handleTollStationVM.stationToUpdate.Boss = (Referent) _handleTollStationVM.SelectedReferent;
            _tollStationService.Update(_handleTollStationVM.stationToUpdate);
        }
    }
}
