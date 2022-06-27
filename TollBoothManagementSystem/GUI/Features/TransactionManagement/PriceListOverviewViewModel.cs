using System.Collections.Generic;
using System.Collections.ObjectModel;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.GUI.Utility.ViewModel;
using System.Linq;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.General.Service;

namespace TollBoothManagementSystem.GUI.Features.TransactionManagement
{
    public class PriceListOverviewViewModel : ViewModelBase
    {
        public class DataTable
        {
            private double _category1ARSD;
            private double _category1RSD;
            private double _category2RSD;
            private double _category3RSD;
            private double _category4RSD;
            private string _stationName;
            private double _category1AEUR;
            private double _category1EUR;
            private double _category2EUR;
            private double _category3EUR;
            private double _category4EUR;

            public double Category1ARSD => _category1ARSD;
            public double Category1RSD => _category1RSD;
            public double Category2RSD => _category2RSD;
            public double Category3RSD => _category3RSD;
            public double Category4RSD => _category4RSD;
            public string StationName => _stationName;
            public double Category1AEUR => _category1AEUR;
            public double Category1EUR => _category1EUR;
            public double Category2EUR => _category2EUR;
            public double Category3EUR => _category3EUR;
            public double Category4EUR => _category4EUR;

            public DataTable(double category1ARSD, double category1RSD, double category2RSD, double category3RSD, double category4RSD,
                string stationName, double category1AEUR, double category1EUR, double category2EUR, double category3EUR, double category4EUR)
            {
                this._category1ARSD = category1ARSD;
                this._category1RSD = category1RSD;
                this._category2RSD = category2RSD;
                this._category3RSD = category3RSD;
                this._category4RSD = category4RSD;
                this._stationName = stationName;
                this._category1AEUR = category1AEUR;
                this._category1EUR = category1EUR;
                this._category2EUR = category2EUR;
                this._category3EUR = category3EUR;
                this._category4EUR = category4EUR;
            }
        }

        #region Attributes

        private IRoadTollService _roadTollService;
        private ISectionRepository _sectionRepository;
        private IPriceListService _priceListService;
        private IRoadTollPriceService _roadTollPriceService;
        private readonly ICurrencyService _currencyService;
        private Section _selectedSection;
        private TollStation _selectedStation;
        private PriceList _selectedPriceList;
        private ObservableCollection<DataTable> _dataTables;

        #endregion

        #region Properties

        public Section SelectedSection
        {
            get => _selectedSection;
            set
            {
                _selectedSection = value;
                OnPropertyChanged(nameof(SelectedSection));
                _selectedPriceList = _priceListService.GetActivePricelist(_selectedSection);
                LoadStations(value);
                OnPropertyChanged(nameof(SelectedStation));
                OnPropertyChanged(nameof(TollStations));
                OnPropertyChanged(nameof(DataTables));
            }
        }

        public TollStation SelectedStation
        {
            get => _selectedStation;
            set
            {
                _selectedStation = value;
                OnPropertyChanged(nameof(SelectedStation));
                OnPropertyChanged(nameof(DataTables));
            }
        }

        public PriceList SelectedPriceList
        {
            get => _selectedPriceList;
            set
            {
                _selectedPriceList = value;
                OnPropertyChanged(nameof(SelectedPriceList));
            }
        }

        #endregion

        #region Collections

        private List<Section> _sections;
        private List<TollStation> _tollStations;

        public List<Section> Sections
        {
            get => _sections;
            set
            {
                _sections = value;
                OnPropertyChanged(nameof(Sections));
            }
        }

        public List<TollStation> TollStations
        {
            get => _tollStations;
            set
            {
                _tollStations = value;
                OnPropertyChanged(nameof(TollStations));
            }
        }

        public IEnumerable<DataTable> DataTables
        {
            get => _dataTables;
        }

        private readonly ObservableCollection<Currency> _currencies;
        public IEnumerable<Currency> Currencies => _currencies;

        #endregion



        private void LoadSections()
        {
            _sections = new List<Section>(_sectionRepository.ReadAll());
            _selectedSection = _sections[0];
            _selectedPriceList = _priceListService.GetActivePricelist(_selectedSection);
            LoadStations(_selectedSection);    
        }

        private void LoadStations(Section section)
        {
            _tollStations = new List<TollStation>();
            _dataTables = new ObservableCollection<DataTable>();

            foreach (var station in section.TollStations)
            {
                _tollStations.Add(station);
                
            }
            _tollStations = _tollStations.OrderBy(x => x.CreatedAt).ToList();
            _selectedStation = _tollStations[0];
            LoadDataTable(_tollStations);
        }

        public void LoadDataTable(List<TollStation> stations)
        {
            foreach (TollStation station in stations)
            {
                LoadDataTableRow(station);
            }
        }

        private void LoadDataTableRow(TollStation station)
        {
            Currency curr = _currencies.First(e => e.Code == "RSD");
            double c1ARSD = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category1A, curr, _tollStations[0], station);
            double c1RSD = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category1, curr, _tollStations[0], station);
            double c2RSD = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category2, curr, _tollStations[0], station);
            double c3RSD = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category3, curr, _tollStations[0], station);
            double c4RSD = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category4, curr, _tollStations[0], station);
            curr = _currencies.First(e => e.Code == "EUR");
            double c1AEUR = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category1A, curr, _tollStations[0], station);
            double c1EUR = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category1, curr, _tollStations[0], station);
            double c2EUR = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category2, curr, _tollStations[0], station);
            double c3EUR = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category3, curr, _tollStations[0], station);
            double c4EUR = _roadTollPriceService.CalculatePrice(_selectedPriceList, VehicleType.Category4, curr, _tollStations[0], station);
            DataTable dt = new DataTable(c1ARSD, c1RSD, c2RSD, c3RSD, c4RSD, station.Name, c1AEUR, c1EUR, c2EUR, c3EUR, c4EUR);
            _dataTables.Add(dt);
        }

        public PriceListOverviewViewModel(IRoadTollService roadTollService, ISectionRepository sectionRepository, IPriceListService priceListService, IRoadTollPriceService roadTollPriceService, ICurrencyService currencyService)
        {
            _roadTollService = roadTollService;
            _sectionRepository = sectionRepository;
            _priceListService = priceListService;
            _roadTollPriceService = roadTollPriceService;
            _currencyService = currencyService;

            _currencies = new ObservableCollection<Currency>(currencyService.ReadAll());

            LoadSections();

            //_currentTollStation = GlobalStore.ReadObject<Administrator>("LoggedUser").TollStation;
            //_currentSection = _sectionService.GetSection(_currentTollStation);
            //_currentPriceList = _priceListService.CurrentPriceListForSection(_currentSection);

            //setRoadTolls();
        }

    }
}
