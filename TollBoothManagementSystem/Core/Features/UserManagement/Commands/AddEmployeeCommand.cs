using System;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.UserManagement;
using TollBoothManagementSystem.GUI.Features.UserManagement.Dialog;
using TollBoothManagementSystem.GUI.Utility.Dialog;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Commands
{
    public class AddEmployeeCommand : CommandBase
    {
        private readonly IDialogService _dialogService;

        private readonly EmployeesViewModel _employeesVM;
        public AddEmployeeCommand(IDialogService dialogService, EmployeesViewModel employeesVM)
        {
            _dialogService = dialogService;
            _employeesVM = employeesVM;
        }

        public override void Execute(object? parameter)
        {
            var userService = ServiceLocator.Get<IUserService>();
            var handleUserVM = new HandleEmployeeViewModel(userService, _employeesVM, Guid.Empty);
            _dialogService.ShowDialog(handleUserVM, isForceClosed =>
            {
                var dialogForceClosed = isForceClosed;
            });
        }
    }
}
