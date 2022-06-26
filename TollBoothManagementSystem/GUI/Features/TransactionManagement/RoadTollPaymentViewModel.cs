using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.ReferentCMD;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.TransactionManagement
{
    public class RoadTollPaymentViewModel : ViewModelBase
    {
        #region Atributes
        private readonly ICurrencyService _currencyService;
        private readonly ITollStationService _tollStationService;
        private readonly ISectionService _sectionService;
        private readonly IRoadTollPriceService _roadTollPriceService;
        private readonly ISectionInfoService _sectionInfoService;
        private readonly ITollBoothService _tollBoothService;
        private readonly IRoadTollPaymentService _roadTollPaymentService;
        private Currency _selectedCurrency;
        private TollStation _selectedStation;
        private readonly TollStation? _currentStation;
        private double _amountPayed;
        private Section _currentSection;
        private VehicleType _selectedVehicleCategory;
        private readonly PriceList _activePricelist;
        private DateTime _enterDate;
        private DateTime _enterTime;
        private string _lpnLeft = "";
        private string _lpnMiddle = "";
        private string _lpnRight = "";
        #endregion

        #region Properties
        public ICurrencyService CurrencyService => _currencyService;
        public ITollStationService TollStationService => _tollStationService;
        public ISectionInfoService SectionInfoService => _sectionInfoService;
        public ITollBoothService TollBoothService => _tollBoothService;
        public IRoadTollPaymentService RoadTollPaymentService => _roadTollPaymentService;
        public string LpnLeft
        {
            get => _lpnLeft;
            set
            {
                _lpnLeft = value.ToString().ToUpper();
                OnPropertyChanged(nameof(LpnLeft));
            }
        }
        public string LpnMiddle
        {
            get => _lpnMiddle;
            set
            {
                _lpnMiddle = value;
                OnPropertyChanged(nameof(LpnMiddle));
            }
        }
        public string LpnRight
        {
            get => _lpnRight;
            set
            {
                _lpnRight = value.ToString().ToUpper();
                OnPropertyChanged(nameof(LpnRight));
            }
        }
        public string LicencePlateNumber
        {
            get
            {
                return LpnLeft + LpnMiddle + LpnRight;
            }
        }
        public DateTime EnterDate
        {
            get => _enterDate;
            set
            {
                _enterDate = value;
                OnPropertyChanged(nameof(EnterDate));
            }
        }
        public DateTime EnterTime
        {
            get => _enterTime;
            set
            {
                _enterTime = value;
                OnPropertyChanged(nameof(EnterTime));
            }
        }
        public DateTime EnterDateTime
        {
            get
            {                
                return EnterDate.Add(EnterTime.TimeOfDay);
            }
        }
        public ISectionService SectionService => _sectionService;
        public IRoadTollPriceService RoadTollPriceService => _roadTollPriceService;
        public Section CurrentSection => _currentSection;
        public PriceList ActivePricelist => _activePricelist;
        public static DateTime Today => DateTime.Today;
        public VehicleType SelectedVehicleCategory
        {
            get => _selectedVehicleCategory;
            set
            {
                _selectedVehicleCategory = value;
                OnPropertyChanged(nameof(SelectedVehicleCategory));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Change));
                OnPropertyChanged(nameof(IsInsufficientAmount));
            }
        }
        public bool IsInsufficientAmount
        {
            get
            {
                return Price > AmountPayed;
            }
        }
        public double Change
        {
            get
            {
                return AmountPayed - Price;
            }
        }
        public double AmountPayed
        {
            get => _amountPayed;
            set
            {
                _amountPayed = value;
                OnPropertyChanged(nameof(AmountPayed));
                OnPropertyChanged(nameof(IsInsufficientAmount));
                OnPropertyChanged(nameof(Change));
            }
        }
        public double Price
        {
            get
            {
                double price = RoadTollPriceService.CalculatePrice(ActivePricelist, SelectedVehicleCategory, SelectedCurrency, SelectedStation, CurrentStation);
                return price;
            }
        }
        public TollStation? CurrentStation => _currentStation;
        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                AmountPayed = 0;
                OnPropertyChanged(nameof(SelectedCurrency));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Change));
                OnPropertyChanged(nameof(IsInsufficientAmount));
            }
        }
        public TollStation SelectedStation
        {
            get => _selectedStation;
            set
            {
                _selectedStation = value;
                OnPropertyChanged(nameof(SelectedStation));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Change));
                OnPropertyChanged(nameof(IsInsufficientAmount));
            }
        }
        #endregion

        #region Collections
        private readonly ObservableCollection<Currency> _currencies;
        public IEnumerable<Currency> Currencies => _currencies;

        private readonly ObservableCollection<TollStation> _tollStations;
        public IEnumerable<TollStation> TollStations => _tollStations;


        #endregion

        #region Commands
        public ICommand ConfirmPaymentCommand { get; }
        #endregion
        public RoadTollPaymentViewModel(ICurrencyService currencyService, ITollStationService tollStationService, ISectionService sectionService, IRoadTollPriceService roadTollPriceService, ISectionInfoService sectionInfoService, ITollBoothService tollBoothService, IRoadTollPaymentService roadTollPaymentService)
        {
            _enterDate = Today;
            _selectedVehicleCategory = VehicleType.Category1A;
            _currentStation = GlobalStore.ReadObject<TollStation>("CurrentTollStation");
            _currencyService = currencyService;
            _tollStationService = tollStationService;
            _sectionService = sectionService;
            _roadTollPriceService = roadTollPriceService;
            _sectionInfoService = sectionInfoService;
            _tollBoothService = tollBoothService;
            _roadTollPaymentService = roadTollPaymentService;
            _currencies = new ObservableCollection<Currency>(currencyService.ReadAll());
            _selectedCurrency = _currencies.First(e => e.Code == "RSD");
            _currentSection = GlobalStore.ReadObject<Section>("CurrentSection");
            _activePricelist = GlobalStore.ReadObject<PriceList>("ActivePricelist");
            _tollStations = new ObservableCollection<TollStation>(_currentSection.TollStations.Where(e => e.Id != _currentStation.Id));
            _selectedStation = _tollStations[0];
            ConfirmPaymentCommand = new ConfirmPaymentCommand(this);
        }
    }
}
