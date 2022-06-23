using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class ManagerHomeViewModel
    {
        #region commands
        public ICommand LogOutCommand { get; set; }
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
            //SwitchCurrentViewModel(ServiceLocator.Get<>());
        }

        #region handlers
        private void RegisterHandler()
        {
            //EventBus.RegisterHandler("PatientAppointments", () =>
            //{
            //    PatientAppointmentsViewModel Pavm = ServiceLocator.Get<PatientAppointmentsViewModel>();
            //    SwitchCurrentViewModel(Pavm);
            //});
        }
        #endregion
    }
}
