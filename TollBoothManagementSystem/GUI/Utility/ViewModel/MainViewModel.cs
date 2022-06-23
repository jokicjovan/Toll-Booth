using System.Windows;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.Navigation;
using TollBoothManagementSystem.GUI.Utility.WindowTitle;

namespace TollBoothManagementSystem.GUI.Utility.ViewModel
{
    public class MainViewModel : NavigableViewModel
    {
        private string _viewTitle;
        public string ViewTitle
        {
            get => _viewTitle;
        }
        private void OnTitleChanged()
        {
            _viewTitle = TitleManager.Title;
            OnPropertyChanged(nameof(ViewTitle));
        }

        public LoginViewModel Lvm { get; set; }

        public MainViewModel(LoginViewModel lvm)
        {
            TitleManager.TitleChanged += OnTitleChanged;
            TitleManager.Title = "Login";
            Lvm = lvm;
            SwitchCurrentViewModel(lvm);
            RegisterHandler();
        }
        private void RegisterHandler()
        {
            EventBus.RegisterHandler("AdministratorLogin", () =>
            {
                AdministratorHomeViewModel Ahvm = ServiceLocator.Get<AdministratorHomeViewModel>();
                SwitchCurrentViewModel(Ahvm);
            });

            EventBus.RegisterHandler("ManagerLogin", () =>
            {
                ManagerHomeViewModel Mhvm = ServiceLocator.Get<ManagerHomeViewModel>();
                SwitchCurrentViewModel(Mhvm);
            });

            EventBus.RegisterHandler("ReferentLogin", () =>
            {
                ReferentHomeViewModel Rhvm = ServiceLocator.Get<ReferentHomeViewModel>();
                SwitchCurrentViewModel(Rhvm);
            });

            EventBus.RegisterHandler("BackToLogin", () =>
            {
                EventBus.Clear();
                ServiceLocator.Reset();
                Lvm = ServiceLocator.Get<LoginViewModel>();
                SwitchCurrentViewModel(Lvm);
                RegisterHandler();
            });
        }

    }
}
