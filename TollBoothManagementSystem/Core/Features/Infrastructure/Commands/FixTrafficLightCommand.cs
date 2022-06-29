using System.ComponentModel;
using System.Windows;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class FixTrafficLightCommand : CommandBase
    {
        private FixTollBoothViewModel _viewModel;
        public FixTrafficLightCommand(FixTollBoothViewModel viewModel)
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
            return !(_viewModel.SelectedTollBooth == null) && !(_viewModel.SelectedTollBooth.IsTrafficLightFunctional == true) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _viewModel.SelectedTollBooth.IsTrafficLightFunctional = true;
            _viewModel.TollBoothService.Update(_viewModel.SelectedTollBooth);
            _viewModel.SelectedTollBooth = null;
            _viewModel.Search();
            MessageBox.Show("TollBooth traffic light fixed successfully");
        }
    }
}
