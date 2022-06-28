using System;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class AddTollStationCommand : CommandBase
    {
        private readonly IDialogService _dialogService;

        private readonly TollStationsViewModel _viewModel;
        public AddTollStationCommand(IDialogService dialogService, TollStationsViewModel viewModel)
        {
            _dialogService = dialogService;
            _viewModel = viewModel;
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
            var handleStationVm = new HandleTollStationViewModel(locationService, tollStationService,  sectionService, sectionInfoService, roadTollPriceService, priceListService, employeeService, _viewModel, Guid.Empty);
            _dialogService.ShowDialog(handleStationVm, isForceClosed =>
            {
                var dialogForceClosed = isForceClosed;
            });
        }
    }
}
