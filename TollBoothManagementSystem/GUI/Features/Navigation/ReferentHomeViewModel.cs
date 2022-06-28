using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.ManagerCMD;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.ReferentCMD;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Ninject;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.TransactionManagement;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class ReferentHomeViewModel : NavigableViewModel
    {
        #region Commands
        public ICommand LogOutCommand { get; set; }
        public ICommand NavigatePaymentCommand { get; set; }
        public ICommand SwitchTollBoothStatusCommand { get; set; }
        public ICommand ReportTrafficLightFaultCommand { get; set; }
        public ICommand ReportGateFaultCommand { get; set; }
        public ICommand OpenStationIncomeReportCommand { get; set; }
        #endregion

        #region Atributes
        private bool _isOpen;
        private ITollBoothService _tollBoothService;
        private TollBooth _currentTollBooth;
        private bool _trafficLightStatus;
        private bool _gateStatus;
        private Visibility _isBoss;
        #endregion

        #region Properties
        public string ButtonContent
        {
            get
            {
                if (IsOpen)
                    return "Toll booth opened";
                return "Toll booth closed";
            }
        }
        public string TollGateFaultContent
        {
            get
            {
                if(CurrentTollBooth.IsTollGateFunctional == false)
                    return "Toll gate not functional";
                else
                    return "Report toll gate fault";
            }
        }
        public string TrafficLightFaultContent
        {
            get
            {
                if (CurrentTollBooth.IsTrafficLightFunctional == false)
                    return "Traffic light not functional";
                else
                    return "Report traffic light fault";
            }
        }

        public bool TrafficLightStatus
        {
            get => _trafficLightStatus;
            set
            {
                _trafficLightStatus = value;
                OnPropertyChanged(nameof(TrafficLightStatus));
            }
        }

        public bool GateStatus
        {
            get => _gateStatus;
            set
            {
                _gateStatus = value;
                OnPropertyChanged(nameof(GateStatus));
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

        public Referent Referent
        {
            get => GlobalStore.ReadObject<Referent>("LoggedUser");
        }

        public TollStation CurrentStation
        {
            get => GlobalStore.ReadObject<TollStation>("CurrentTollStation");
        }
        public TollBooth CurrentTollBooth
        {
            get => _currentTollBooth;
            set
            {
                _currentTollBooth = value;
                OnPropertyChanged(nameof(CurrentTollBooth));
            }
        }
        public Visibility IsBoss
        {
            get => _isBoss;
            set
            {
                _isBoss = value;
                OnPropertyChanged(nameof(IsBoss));
            }
        }

        #endregion

        private void CheckBoss()
        {
            if (CurrentStation.Boss.Id == Referent.Id)
            {
                _isBoss = Visibility.Visible;
                return;
            }
            _isBoss = Visibility.Hidden;
        }

        public ReferentHomeViewModel(ITollBoothService tollBoothService)
        {
            _currentTollBooth = tollBoothService.Read(GlobalStore.ReadObject<Guid>("CurrentTollBooth"));
            _tollBoothService = tollBoothService;
            CheckBoss();
            LogOutCommand = new LogOutCommand();
            NavigatePaymentCommand = new NavigatePaymentCommand();
            SwitchTollBoothStatusCommand = new SwitchTollBoothStatusCommand(this);
            ReportTrafficLightFaultCommand = new ReportTrafficLightFaultCommand(ServiceLocator.Get<IDialogService>(), this);
            ReportGateFaultCommand = new ReportGateFaultCommand(ServiceLocator.Get<IDialogService>(), this);
            OpenStationIncomeReportCommand = new OpenStationIncomeReportCommand();
            IsOpen = _currentTollBooth.IsOpen;
            TrafficLightStatus = CurrentTollBooth.IsTrafficLightFunctional;
            GateStatus = CurrentTollBooth.IsTollGateFunctional;
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

            EventBus.RegisterHandler("StationIncomeReport", () =>
            {
                ICurrencyService currencyService = ServiceLocator.Get<ICurrencyService>();
                ITollBoothService tollBoothService = ServiceLocator.Get<ITollBoothService>();
                StationIncomeReportViewModel Sirvm = new StationIncomeReportViewModel(currencyService, tollBoothService, CurrentStation);
                SwitchCurrentViewModel(Sirvm);
            });
        }
        #endregion
    }
}
