using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Features.UserManagement;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class AdministratorHomeViewModel : NavigableViewModel
    {
        #region commands
        public ICommand LogOutCommand { get; set; }
        public ICommand OpenTollStationsManagementCommand { get; set; }
        #endregion

        #region properties
        public string FirstName
        {
            get => GlobalStore.ReadObject<Administrator>("LoggedUser").FirstName;
        }
        #endregion

        public AdministratorHomeViewModel() {
            LogOutCommand = new LogOutCommand();
            OpenTollStationsManagementCommand = new OpenTollStationsManagementCommand();
            RegisterHandler();
            SwitchCurrentViewModel(ServiceLocator.Get<TollStationsViewModel>());
        }

        #region handlers
        private void RegisterHandler()
        {
            EventBus.RegisterHandler("TollStationsManagement", () =>
            {
                TollStationsViewModel Tsvm = ServiceLocator.Get<TollStationsViewModel>();
                SwitchCurrentViewModel(Tsvm);
            });
        }
        #endregion
    }
}
