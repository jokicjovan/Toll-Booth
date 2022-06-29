using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using System.ComponentModel;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class UpdateTollStationCommand : CommandBase
    {
        private readonly IDialogService _dialogService;

        private readonly TollStationsViewModel _viewModel;
        public UpdateTollStationCommand(IDialogService dialogService, TollStationsViewModel viewModel)
        {
            _dialogService = dialogService;
            _viewModel = viewModel;
            viewModel.PropertyChanged += OnViewModelPropertyChanged;
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
            return !(_viewModel.SelectedTollStation == null) && !(_viewModel.SelectedSection.Origin.Id == _viewModel.SelectedTollStation.Id)
                && !(_viewModel.SelectedSection.Destination.Id == _viewModel.SelectedTollStation.Id) && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            var tollStationService = ServiceLocator.Get<ITollStationService>();
            var locationService = ServiceLocator.Get<ILocationService>();
            var sectionService = ServiceLocator.Get<ISectionService>();
            var sectionInfoService = ServiceLocator.Get<ISectionInfoService>();
            var priceListService = ServiceLocator.Get<IPriceListService>();
            var roadTollPriceService = ServiceLocator.Get<IRoadTollPriceService>();
            var employeeService = ServiceLocator.Get<IEmployeeService>();
            var handleStationVm = new HandleTollStationViewModel(locationService, tollStationService,
                sectionService, sectionInfoService, roadTollPriceService, priceListService, employeeService, _viewModel, _viewModel.SelectedTollStation.Id);
            _dialogService.ShowDialog(handleStationVm, isForceClosed =>
            {
                var dialogForceClosed = isForceClosed;
            });
        }
    }
}
