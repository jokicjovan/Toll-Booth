using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.AdministratorCMD;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.Infrastructure;
using TollBoothManagementSystem.GUI.Features.TransactionManagement;
using TollBoothManagementSystem.GUI.Features.UserManagement;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class AdministratorHomeViewModel : NavigableViewModel
    {
        #region Commands
        public ICommand LogOutCommand { get; set; }
        public ICommand OpenTollStationsManagementCommand { get; set; }
        public ICommand OpenGlobalIncomeReportCommand { get; set; }
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
            OpenGlobalIncomeReportCommand = new OpenGlobalIncomeReportCommand();
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
                    if (Tsvm.SelectedTollStation != null) 
                    {
                        var tollBoothService = ServiceLocator.Get<ITollBoothService>();
                        var tollStationService = ServiceLocator.Get<ITollStationService>();
                        var dialogService = ServiceLocator.Get<IDialogService>();
                        TollBoothsViewModel Tbvm = new TollBoothsViewModel(tollBoothService, tollStationService, dialogService, Tsvm.SelectedTollStation.Id);
                        SwitchCurrentViewModel(Tbvm);
                    }
                });

                EventBus.RegisterHandler("AllEmployeesManagement", () =>
                {
                    if (Tsvm.SelectedTollStation != null)
                    {
                        var employeeService = ServiceLocator.Get<IEmployeeService>();
                        var tollStationService = ServiceLocator.Get<ITollStationService>();
                        var dialogService = ServiceLocator.Get<IDialogService>();
                        EmployeesViewModel Evm = new EmployeesViewModel(employeeService, tollStationService, dialogService, Tsvm.SelectedTollStation.Id);
                        SwitchCurrentViewModel(Evm);
                    }
                });
            });
            EventBus.RegisterHandler("GlobalIncomeReport", () =>
            {
                GlobalIncomeReportViewModel viewModel = ServiceLocator.Get<GlobalIncomeReportViewModel>();
                SwitchCurrentViewModel(viewModel);

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
