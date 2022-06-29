using System;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
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
        private readonly ITollStationService _tollStationService;

        private readonly EmployeesViewModel _employeesVM;
        public AddEmployeeCommand(IDialogService dialogService, ITollStationService tollStationService, EmployeesViewModel employeesVM)
        {
            _dialogService = dialogService;
            _tollStationService = tollStationService;
            _employeesVM = employeesVM;
        }

        public override void Execute(object? parameter)
        {
            var userService = ServiceLocator.Get<IUserService>();
            var handleUserVM = new HandleEmployeeViewModel(userService, _tollStationService, _employeesVM, Guid.Empty, _employeesVM.TollStation);
            _dialogService.ShowDialog(handleUserVM, isForceClosed =>
            {
                var dialogForceClosed = isForceClosed;
            });
        }
    }
}
