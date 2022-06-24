using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.ReferentCMD;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.TransactionManagement;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class ReferentHomeViewModel : NavigableViewModel
    {
        #region commands
        public ICommand LogOutCommand { get; set; }
        public ICommand NavigatePaymentCommand { get; set; }
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
            NavigatePaymentCommand = new NavigatePaymentCommand();
            RegisterHandler();
            EventBus.FireEvent("ShowPaymentWindow");
        }

        #region handlers
        private void RegisterHandler()
        {
            EventBus.RegisterHandler("ShowPaymentWindow", () =>
            {
                RoadTollPaymentViewModel viewModel = ServiceLocator.Get<RoadTollPaymentViewModel>();              
                SwitchCurrentViewModel(viewModel);
            });
        }
        #endregion
    }
}
