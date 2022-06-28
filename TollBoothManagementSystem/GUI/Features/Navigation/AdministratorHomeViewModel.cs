using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.AdministratorCMD;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Features.TransactionManagement;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class AdministratorHomeViewModel : NavigableViewModel
    {
        #region Commands
        public ICommand LogOutCommand { get; set; }
        public ICommand OpenTollStationsManagementCommand { get; set; }
        public ICommand PriceListOverviewCommand { get; set; }
        #endregion

        #region Properties
        public string FirstName
        {
            get => GlobalStore.ReadObject<Administrator>("LoggedUser").FirstName;
        }
        #endregion

        public AdministratorHomeViewModel() {
            LogOutCommand = new LogOutCommand();
            OpenTollStationsManagementCommand = new OpenTollStationsManagementCommand();
            PriceListOverviewCommand = new PriceListOverviewCommand();
            RegisterHandler();
            EventBus.FireEvent("TollStationsManagement");
        }

        #region Handlers
        private void RegisterHandler()
        {
            EventBus.RegisterHandler("TollStationsManagement", () =>
            {
                TollStationsViewModel Tsvm = ServiceLocator.Get<TollStationsViewModel>();
                SwitchCurrentViewModel(Tsvm);

                EventBus.RegisterHandler("TollBoothsManagement", () =>
                {
                    var tollBoothService = ServiceLocator.Get<TollBoothService>();
                    var tollStationService = ServiceLocator.Get<TollStationService>();
                    var dialogService = ServiceLocator.Get<DialogService>();
                    TollBoothsViewModel Tbvm = new TollBoothsViewModel(tollBoothService, tollStationService, dialogService, Tsvm.SelectedTollStation.Id);
                    SwitchCurrentViewModel(Tbvm);
                });
            });

            EventBus.RegisterHandler("PriceListOverview", () =>
            {
                PriceListOverviewViewModel Plvm = ServiceLocator.Get<PriceListOverviewViewModel>();
                SwitchCurrentViewModel(Plvm);
            });
        }
        #endregion
    }
}
