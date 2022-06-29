using System.ComponentModel;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.UserManagement;
using TollBoothManagementSystem.GUI.Features.UserManagement.Dialog;
using TollBoothManagementSystem.GUI.Utility.Dialog;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Commands
{
    public class UpdateEmployeeCommand : CommandBase
    {
        private readonly IDialogService _dialogService;
        private readonly ITollStationService _tollStationService;

        private readonly EmployeesViewModel _employeesVM;
        public UpdateEmployeeCommand(IDialogService dialogService, ITollStationService tollStationService, EmployeesViewModel employeesVM)
        {
            _tollStationService = tollStationService;
            _dialogService = dialogService;
            _employeesVM = employeesVM;
            _employeesVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_employeesVM.SelectedEmployee))
            {
                OnCanExecuteChange();
            }
        }

        public override void Execute(object? parameter)
        {
            var userService = ServiceLocator.Get<IUserService>();
            var handleUserVM = new HandleEmployeeViewModel(userService, _tollStationService,
                _employeesVM, _employeesVM.SelectedEmployee.Id, _employeesVM.TollStation);
            _dialogService.ShowDialog(handleUserVM, isForceClosed =>
            {
                var dialogForceClosed = isForceClosed;
            });
        }

        public override bool CanExecute(object? parameter)
        {
            return _employeesVM.SelectedEmployee != null;
        }
    }
}
