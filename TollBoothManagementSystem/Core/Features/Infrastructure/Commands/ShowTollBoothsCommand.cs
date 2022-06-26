using System.ComponentModel;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.Infrastructure;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class ShowTollBoothsCommand : CommandBase
    {
        private TollStationsViewModel _viewModel;
        public ShowTollBoothsCommand(TollStationsViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedTollStation))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedTollStation != null;
        }
        public override void Execute(object? parameter)
        {
            EventBus.FireEvent("TollBoothsManagement");
        }
    }
}
