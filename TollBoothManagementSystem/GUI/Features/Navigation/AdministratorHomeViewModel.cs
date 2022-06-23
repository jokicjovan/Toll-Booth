using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.UserManagement;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class AdministratorHomeViewModel : NavigableViewModel
    {
        #region commands
        public ICommand LogOutCommand { get; set; }
        #endregion

        #region properties
        public string FirstName
        {
            get => GlobalStore.ReadObject<Administrator>("LoggedUser").FirstName;
        }
        #endregion

        public AdministratorHomeViewModel() {
            LogOutCommand = new LogOutCommand();
            RegisterHandler();
            SwitchCurrentViewModel(ServiceLocator.Get<EmployeesViewModel>());
        }

        #region handlers
        private void RegisterHandler()
        {
            EventBus.RegisterHandler("EmployeesManagement", () =>
            {
                EmployeesViewModel Evm = ServiceLocator.Get<EmployeesViewModel>();
                SwitchCurrentViewModel(Evm);
            });
        }
        #endregion
    }
}
