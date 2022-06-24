using System.ComponentModel;
using System.Windows;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.UserManagement;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Commands
{
    public class DeleteEmployeeCommand : CommandBase
    {
        EmployeesViewModel _viewModel;
        public DeleteEmployeeCommand(EmployeesViewModel viewModel) {
            _viewModel = viewModel; 
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedEmployee))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            var currentManager = GlobalStore.ReadObject<Manager>("LoggedUser");
            return !(_viewModel.SelectedEmployee == null || _viewModel.SelectedEmployee.Id == currentManager.Id
                || _viewModel.SelectedEmployee.Id == currentManager.TollStation.Boss.Id) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _viewModel.EmployeeService.Delete(_viewModel.SelectedEmployee.Id);
            _viewModel.SearchEmployee();
            MessageBox.Show("Employee deleted successfully");
        }
    }
}
