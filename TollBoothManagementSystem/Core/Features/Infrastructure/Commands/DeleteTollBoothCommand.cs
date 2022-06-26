using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class DeleteTollBoothCommand : CommandBase
    {
        private TollBoothsViewModel _viewModel;
        public DeleteTollBoothCommand(TollBoothsViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedTollBooth))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !(_viewModel.SelectedTollBooth == null) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _viewModel.TollBoothService.Delete(_viewModel.SelectedTollBooth.Id);
            _viewModel.SearchTollBooth();
            MessageBox.Show("TollStation deleted successfully");
        }
    }
}
