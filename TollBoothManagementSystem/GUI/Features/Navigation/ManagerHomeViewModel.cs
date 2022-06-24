using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.UserManagement;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class ManagerHomeViewModel : NavigableViewModel
    {
        #region commands
        public ICommand LogOutCommand { get; set; }
        public ICommand OpenEmployeesManagementCommand { get; set; }
        #endregion

        #region properties
        public string FirstName
        {
            get => GlobalStore.ReadObject<Manager>("LoggedUser").FirstName;
        }
        #endregion

        public ManagerHomeViewModel()
        {
            LogOutCommand = new LogOutCommand();
            RegisterHandler();
            SwitchCurrentViewModel(ServiceLocator.Get<EmployeesViewModel>());
            LogOutCommand = new LogOutCommand();
            OpenEmployeesManagementCommand = new OpenEmployeesManagementCommand();
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
