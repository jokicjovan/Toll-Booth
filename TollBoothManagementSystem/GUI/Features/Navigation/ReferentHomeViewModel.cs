using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
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
        public ICommand SwitchTollBoothStatusCommand { get; set; }
        #endregion

        #region Atributes
        private bool _isOpen;
        private ITollBoothService _tollBoothService;
        private TollBooth _currentTollBooth;
        #endregion

        #region properties
        public string ButtonContent
        {
            get
            {
                if (IsOpen)
                    return "Toll booth opened";
                return "Toll booth closed";
            }
        }
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                _currentTollBooth.IsOpen = value;
                _tollBoothService.Update(_currentTollBooth);
                OnPropertyChanged(nameof(IsOpen));
                OnPropertyChanged(nameof(ButtonContent));
            }
        }
        public string FirstName
        {
            get => GlobalStore.ReadObject<Referent>("LoggedUser").FirstName;
        }

        public TollStation CurrentStation
        {
            get => GlobalStore.ReadObject<TollStation>("CurrentTollStation");
        }

        #endregion

        public ReferentHomeViewModel(ITollBoothService tollBoothService)
        {
            LogOutCommand = new LogOutCommand();
            NavigatePaymentCommand = new NavigatePaymentCommand();
            _currentTollBooth = tollBoothService.Read(GlobalStore.ReadObject<Guid>("CurrentTollBooth"));
            _tollBoothService = tollBoothService;
            SwitchTollBoothStatusCommand = new SwitchTollBoothStatusCommand(this);
            IsOpen = _currentTollBooth.IsOpen;
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
