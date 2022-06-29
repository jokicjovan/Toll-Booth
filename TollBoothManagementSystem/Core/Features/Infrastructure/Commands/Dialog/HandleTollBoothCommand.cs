using System.Windows;
using System;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using System.Linq;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands.Dialog
{
    public class HandleTollBoothCommand : CommandBase
    {
        private readonly ITollBoothService _tollBoothService;
        private readonly ITollStationService _tollStationService;
        private readonly TollBoothsViewModel _tollBoothsVM;
        private readonly HandleTollBoothViewModel _handleTollBoothVM;
        private TollStation _tollStation;

        private Guid _tollBoothId;

        public HandleTollBoothCommand(ITollBoothService tollBoothService, ITollStationService tollStationService, TollBoothsViewModel tollBoothsVM,
            HandleTollBoothViewModel handleTollBoothVM, Guid tollBoothId, TollStation tollStation)
        {
            _tollStationService = tollStationService;
            _tollBoothService = tollBoothService;
            _tollBoothsVM = tollBoothsVM;
            _handleTollBoothVM = handleTollBoothVM;
            _tollBoothId = tollBoothId;
            _tollStation = tollStation;
            _handleTollBoothVM.PropertyChanged += _handleTollBoothsVM_PropertyChanged;
        }

        private void _handleTollBoothsVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HandleTollBoothViewModel.CanExecute))
            {
                OnCanExecuteChange(sender, e);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _handleTollBoothVM.CanExecute;
        }

        public override void Execute(object? parameter)
        {
            if (_tollStation.TollBooths.Any(tb => tb.Code.ToLower() == _handleTollBoothVM.BoothCode.ToLower()))
            {
                _handleTollBoothVM.BoothCodeError.ErrorMessage = "Booth code must be unique";
                return;
            }


            if (_tollBoothId == Guid.Empty)
            {
                HandleAction(parameter, AddBooth);
                MessageBox.Show("Booth added successfully");
            }
            else
            {
                HandleAction(parameter, UpdateBooth);
                MessageBox.Show("Booth updated successfully");
            }
        }

        public void HandleAction(object parameter, Action action)
        {
            action();
            _tollBoothsVM.Search();
            _handleTollBoothVM.ResetFields();
            var dialog = (DialogWindow)parameter;
            dialog.Close();
        }

        public void AddBooth()
        {
            var newTollBooth = new TollBooth()
            {
                Code = _handleTollBoothVM.BoothCode,
                IsETC = (bool)_handleTollBoothVM.IsETC,
                IsOpen = (bool)_handleTollBoothVM.IsOpen,
                IsTollGateFunctional = (bool)_handleTollBoothVM.IsTollGateFunctional,
                IsTrafficLightFunctional = (bool)_handleTollBoothVM.IsTrafficLightFunctional,
                TollStation = _tollStation
            };

            _tollStation.TollBooths.Add(newTollBooth);
            _tollStationService.Update(_tollStation);
        }

        public void UpdateBooth()
        {
            var boothToUpdate = _tollBoothService.Read(_tollBoothId);

            boothToUpdate.Code = _handleTollBoothVM.BoothCode;
            boothToUpdate.IsETC = (bool)_handleTollBoothVM.IsETC;
            boothToUpdate.IsOpen = (bool)_handleTollBoothVM.IsOpen;
            boothToUpdate.IsTollGateFunctional = (bool)_handleTollBoothVM.IsTollGateFunctional;
            boothToUpdate.IsTrafficLightFunctional = (bool)_handleTollBoothVM.IsTrafficLightFunctional;

            _tollBoothService.Update(boothToUpdate);
        }
    }
}
