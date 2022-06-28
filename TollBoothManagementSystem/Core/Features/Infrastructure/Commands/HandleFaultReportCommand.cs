using System;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog;
using TollBoothManagementSystem.GUI.Features.Navigation;
using TollBoothManagementSystem.GUI.Utility.Dialog;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class HandleFaultReportCommand : CommandBase
    {
        private readonly ITollBoothService _tollBoothService;
        private readonly IUserService _userService;
        private readonly IFaultReportService _faultReportService;
        private readonly ReferentHomeViewModel _referentHomeVM;
        private readonly HandleFaultReportViewModel _handleFaultReportVM;
        private FaultType _faultType;

        public HandleFaultReportCommand(IUserService userService, ITollBoothService tollBoothService, IFaultReportService faultReportService, ReferentHomeViewModel referentHomeVM,
            HandleFaultReportViewModel handleFaultReportVM, FaultType faultType)
        {
            _tollBoothService = tollBoothService;
            _userService = userService;
            _faultReportService = faultReportService;
            _referentHomeVM = referentHomeVM;
            _handleFaultReportVM = handleFaultReportVM;
            _handleFaultReportVM.PropertyChanged += _handleEmployeeVM_PropertyChanged;
            _faultType = faultType;
        }

        private void _handleEmployeeVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HandleFaultReportViewModel.CanExecute))
            {
                OnCanExecuteChange(sender, e);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _handleFaultReportVM.CanExecute;
        }

        public override void Execute(object? parameter)
        {
            HandleAction(parameter, SendFaultReport);
        }

        public void HandleAction(object parameter, Action action)
        {
            action();
            _handleFaultReportVM.ResetFields();
            var dialog = (DialogWindow)parameter;
            dialog.DialogResult = true;
            dialog.Close();
        }

        public void SendFaultReport()
        {
            var description = _handleFaultReportVM.Description;

            var newFaultReport = new FaultReport()
            {
                Description = description,
                TollBooth = _referentHomeVM.CurrentTollBooth,
                Reporter = (Referent)_userService.Read(GlobalStore.ReadObject<Referent>("LoggedUser").Id),
                DateOfReport = DateTime.Now
            };

            _faultReportService.Create(newFaultReport);

            _referentHomeVM.CurrentTollBooth.IsOpen = false;
            if (_faultType == FaultType.TrafficLight)
            {
                _referentHomeVM.CurrentTollBooth.IsTrafficLightFunctional = false;
                _tollBoothService.Update(_referentHomeVM.CurrentTollBooth);
            }
            else
            {
                _referentHomeVM.CurrentTollBooth.IsTollGateFunctional = false;
                _tollBoothService.Update(_referentHomeVM.CurrentTollBooth);
            }
        }
    }
}
