using System.ComponentModel;
using System.Windows;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.UserManagement;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Commands
{
    public class MakeBossCommand : CommandBase
    {
        private EmployeesViewModel _viewModel;
        public MakeBossCommand(EmployeesViewModel viewModel)
        {
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
            return !(_viewModel.SelectedEmployee == null || _viewModel.SelectedEmployee.Role == Role.Manager) && 
                !(_viewModel.TollStation.Boss == null || _viewModel.TollStation.Boss.Id == _viewModel.SelectedEmployee.Id) 
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _viewModel.TollStation.Boss = (Referent)_viewModel.SelectedEmployee;
            _viewModel.TollStationService.Update(_viewModel.TollStation);
            _viewModel.SelectedEmployee = null;
            _viewModel.Search();
            MessageBox.Show("Employee promoted successfully");
        }
    }
}
