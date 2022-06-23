using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class ReferentHomeViewModel
    {
        #region commands
        public ICommand LogOutCommand { get; set; }
        #endregion

        #region properties
        public string FirstName
        {
            get => GlobalStore.ReadObject<Referent>("LoggedUser").FirstName;
        }
        #endregion

        public ReferentHomeViewModel()
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
