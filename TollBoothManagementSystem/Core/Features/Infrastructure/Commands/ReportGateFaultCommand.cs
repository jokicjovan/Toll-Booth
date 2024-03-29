﻿using System.ComponentModel;
using System.Windows;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog;
using TollBoothManagementSystem.GUI.Features.Navigation;
using TollBoothManagementSystem.GUI.Utility.Dialog;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class ReportGateFaultCommand : CommandBase
    {
        private readonly IDialogService _dialogService;

        private readonly ReferentHomeViewModel _referentHomeViewModel;

        public ReportGateFaultCommand(IDialogService dialogService, ReferentHomeViewModel referentHomeViewModel)
        {
            _dialogService = dialogService;
            _referentHomeViewModel = referentHomeViewModel;
            _referentHomeViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_referentHomeViewModel.GateStatus))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !(_referentHomeViewModel.GateStatus == false) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            var userService = ServiceLocator.Get<IUserService>();
            var tollBoothService = ServiceLocator.Get<ITollBoothService>();
            var faultReportService = ServiceLocator.Get<IFaultReportService>();

            var handleFaultReportVM = new HandleFaultReportViewModel(userService, tollBoothService, faultReportService, _referentHomeViewModel, FaultType.Gate);
            _dialogService.ShowDialog(handleFaultReportVM, isForceClosed =>
            {
                var dialogClosedNormally = (bool)isForceClosed;

                if (dialogClosedNormally)
                {
                    _referentHomeViewModel.GateStatus = false;
                    _referentHomeViewModel.OnPropertyChanged(nameof(_referentHomeViewModel.TollGateFaultContent));
                    MessageBox.Show("Toll booth gate fault reported successfully");
                }
            });
        }
    }
}
