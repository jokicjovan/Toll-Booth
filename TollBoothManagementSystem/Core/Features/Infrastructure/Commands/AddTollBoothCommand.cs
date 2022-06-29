using System;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog;
using TollBoothManagementSystem.GUI.Utility.Dialog;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class AddTollBoothCommand : CommandBase
    {
        private readonly IDialogService _dialogService;

        private readonly TollBoothsViewModel _viewModel;

        private readonly TollStation _tollStation;
        public AddTollBoothCommand(IDialogService dialogService, TollBoothsViewModel viewModel, 
            TollStation tollStation)
        {
            _dialogService = dialogService;
            _tollStation = tollStation;
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            var tollBoothService = ServiceLocator.Get<ITollBoothService>();
            var tollStationService = ServiceLocator.Get<ITollStationService>();
            var handleStationVm = new HandleTollBoothViewModel(tollBoothService, tollStationService, _viewModel, Guid.Empty, _tollStation);
            _dialogService.ShowDialog(handleStationVm, isForceClosed =>
            {
                var dialogForceClosed = isForceClosed;
            });
        }
    }
}
