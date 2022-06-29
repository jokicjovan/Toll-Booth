using System.ComponentModel;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using System;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class UpdateTollBoothCommand : CommandBase
    {
        private readonly IDialogService _dialogService;

        private readonly TollBoothsViewModel _viewModel;

        private readonly TollStation _tollStation;
        public UpdateTollBoothCommand(IDialogService dialogService, TollBoothsViewModel viewModel, TollStation tollStation)
        {
            _dialogService = dialogService;
            _viewModel = viewModel;
            _tollStation = tollStation;
            viewModel.PropertyChanged += OnViewModelPropertyChanged;
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
            return !(_viewModel.SelectedTollBooth == null)  && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            var tollBoothService = ServiceLocator.Get<ITollBoothService>();
            var tollStationService = ServiceLocator.Get<ITollStationService>();
            var handleStationVm = new HandleTollBoothViewModel(tollBoothService, tollStationService, _viewModel, _viewModel.SelectedTollBooth.Id, _tollStation);
            _dialogService.ShowDialog(handleStationVm, isForceClosed =>
            {
                var dialogForceClosed = isForceClosed;
            });
        }
    }
}
