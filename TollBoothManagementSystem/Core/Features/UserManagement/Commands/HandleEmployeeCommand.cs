using System;
using System.Windows;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.UserManagement;
using TollBoothManagementSystem.GUI.Features.UserManagement.Dialog;
using TollBoothManagementSystem.GUI.Utility.Dialog;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Commands
{
    public class HandleEmployeeCommand : CommandBase
    {
        private readonly IUserService _userService;
        private readonly EmployeesViewModel _employeesVM;
        private readonly HandleEmployeeViewModel _handleEmployeeVM;

        private Guid _employeeId;

        public HandleEmployeeCommand(IUserService userService, EmployeesViewModel employeesVM,
            HandleEmployeeViewModel handleEmployeeVM, Guid employeeId)
        {
            _userService = userService;
            _employeesVM = employeesVM;
            _handleEmployeeVM = handleEmployeeVM;
            _employeeId = employeeId;
            _handleEmployeeVM.PropertyChanged += _handleEmployeeVM_PropertyChanged;
        }

        private void _handleEmployeeVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HandleEmployeeViewModel.CanExecute))
            {
                OnCanExecuteChange(sender, e);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _handleEmployeeVM.CanExecute;
        }

        public override void Execute(object? parameter)
        {
            if (_employeeId == Guid.Empty)
            {
                if (!_userService.IsEmailUsed(_handleEmployeeVM.EmailAddress))
                {
                    HandleAction(parameter, AddEmployee);
                    MessageBox.Show("Employee added successfully");
                }
                else
                {
                    _handleEmployeeVM.EmailAddressError.ErrorMessage = "Email already in use.";
                }
            }
            else
            {
                HandleAction(parameter, UpdateEmployee);
                MessageBox.Show("Employee updated successfully");
            }
        }

        public void HandleAction(object parameter, Action action)
        {
            action();
            _employeesVM.SearchEmployee();
            _handleEmployeeVM.ResetFields();
            var dialog = (DialogWindow)parameter;
            dialog.Close();
        }

        public void AddEmployee()
        {
            var emailAddress = _handleEmployeeVM.EmailAddress;
            var password = _handleEmployeeVM.Password;
            var firstName = _handleEmployeeVM.FirstName;
            var lastName = _handleEmployeeVM.LastName;
            var dateOfBirth = _handleEmployeeVM.DateOfBirth;
            var role = _handleEmployeeVM.ChosenRole;

            if (role == Role.Referent)
            {
                var newEmployee = new Referent()
                {
                    EmailAddress = emailAddress,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Role = Role.Referent
                };
                _userService.Create(newEmployee);
            } 
            else
            {
                var newEmployee = new Manager()
                {
                    EmailAddress = emailAddress,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Role = Role.Referent
                };
                _userService.Create(newEmployee);
            }
        }

        public void UpdateEmployee()
        {
            var employeeToUpdate = _userService.Read(_employeeId);

            employeeToUpdate.EmailAddress = _handleEmployeeVM.EmailAddress;
            employeeToUpdate.Password = _handleEmployeeVM.Password;
            employeeToUpdate.FirstName = _handleEmployeeVM.FirstName;
            employeeToUpdate.LastName = _handleEmployeeVM.LastName;
            employeeToUpdate.DateOfBirth = _handleEmployeeVM.DateOfBirth;
            employeeToUpdate.Role = (Role)_handleEmployeeVM.ChosenRole;

            _userService.Update(employeeToUpdate);
        }
    }
}
