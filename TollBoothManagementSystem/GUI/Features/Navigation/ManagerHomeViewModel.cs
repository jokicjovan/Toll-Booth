using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.ManagerCMD;
using TollBoothManagementSystem.Core.Features.UserManagement.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Features.TransactionManagement;
using TollBoothManagementSystem.GUI.Features.UserManagement;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class ManagerHomeViewModel : NavigableViewModel
    {
        #region commands
        public ICommand LogOutCommand { get; set; }
        public ICommand OpenEmployeesManagementCommand { get; set; }
        public ICommand OpenStationIncomeReportCommand { get; set; }
        public ICommand OpenFixTollBoothCommand { get; set; }
        #endregion

        #region properties
        private Manager _manager;
        public Manager Manager
        {
            get => _manager;
            set
            {
                _manager = value;
                OnPropertyChanged(nameof(Manager));
            }
        }
        #endregion

        public ManagerHomeViewModel()
        {
            _manager = GlobalStore.ReadObject<Manager>("LoggedUser");
            RegisterHandler();
            SwitchCurrentViewModel(ServiceLocator.Get<EmployeesViewModel>());
            LogOutCommand = new LogOutCommand();
            OpenEmployeesManagementCommand = new OpenEmployeesManagementCommand();
            OpenStationIncomeReportCommand = new OpenStationIncomeReportCommand();
            OpenFixTollBoothCommand = new OpenFixTollBoothCommand();
        }

        #region handlers
        private void RegisterHandler()
        {
            EventBus.RegisterHandler("EmployeesManagement", () =>
            {
                EmployeesViewModel Evm = ServiceLocator.Get<EmployeesViewModel>();
                SwitchCurrentViewModel(Evm);
            });

            EventBus.RegisterHandler("FixTollBooth", () =>
            {
                FixTollBoothViewModel Tbsvm = ServiceLocator.Get<FixTollBoothViewModel>();
                SwitchCurrentViewModel(Tbsvm);
            });

            EventBus.RegisterHandler("StationIncomeReport", () =>
            {
                ICurrencyService currencyService = ServiceLocator.Get<ICurrencyService>();
                ITollBoothService tollBoothService = ServiceLocator.Get<ITollBoothService>();
                StationIncomeReportViewModel Sirvm = new StationIncomeReportViewModel(currencyService, tollBoothService, Manager.TollStation);
                SwitchCurrentViewModel(Sirvm);
            });
        }
        #endregion
    }
}
