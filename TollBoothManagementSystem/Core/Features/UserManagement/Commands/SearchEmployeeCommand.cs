﻿using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.UserManagement;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Commands
{
    public class SearchEmployeeCommand : CommandBase
    {
        EmployeesViewModel _viewModel;
        public SearchEmployeeCommand(EmployeesViewModel viewModel)
        {
            _viewModel = viewModel;

        }

        public override void Execute(object? parameter)
        {
            _viewModel.SearchEmployee();
        }
    }
}
