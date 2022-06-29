using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands.Dialog;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.Validation;

namespace TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog
{
    public class HandleTollStationViewModel : DialogViewModelBase<HandleTollStationViewModel>
    {
        #region Properties

        private string _stationName;
        [ValidationField]
        public string StationName
        {
            get { return _stationName; }
            set { _stationName = value; OnPropertyChanged(nameof(StationName)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private ObservableCollection<Location> _allLocations;
        public ObservableCollection<Location> AllLocations
        {
            get { return _allLocations; }
            set { _allLocations = value; OnPropertyChanged(nameof(AllLocations)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private Location? _selectedLocation;
        [ValidationField]
        public Location? SelectedLocation
        {
            get { return _selectedLocation; }
            set { _selectedLocation = value; OnPropertyChanged(nameof(SelectedLocation)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private ObservableCollection<Section> _allSections;
        public ObservableCollection<Section> AllSections
        {
            get { return _allSections; }
            set { _allSections = value; OnPropertyChanged(nameof(AllSections)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private Section? _selectedSection;
        [ValidationField]
        public Section? SelectedSection
        {
            get { return _selectedSection; }
            set { _selectedSection = value; OnPropertyChanged(nameof(SelectedSection)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private ObservableCollection<Employee> _allReferents;
        public ObservableCollection<Employee> AllReferents
        {
            get { return _allReferents; }
            set { _allReferents = value; OnPropertyChanged(nameof(AllReferents)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private Employee? _selectedReferent;
        [ValidationField]
        public Employee? SelectedReferent
        {
            get { return _selectedReferent; }
            set { _selectedReferent = value; OnPropertyChanged(nameof(SelectedReferent)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private string _distance;
        [ValidationField]
        public string Distance
        {
            get { return _distance; }
            set { _distance = value; OnPropertyChanged(nameof(Distance)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private string _price;
        [ValidationField]
        public string Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private string _orderNumber;
        [ValidationField]
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; OnPropertyChanged(nameof(OrderNumber)); OnPropertyChanged(nameof(CanExecute)); }
        }

        #endregion

        #region Additional properties

        private Guid _stationId;

        public TollStation? stationToUpdate;

        public bool ReadOnlySection { get; private set; }

        #endregion

        #region Error message view models

        public ErrorMessageViewModel StationNameError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel LocationError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel SectionError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel DistanceError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel PriceError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel OrderNumberError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel ReferentError { get; private set; } = new ErrorMessageViewModel();


        public bool CanExecute => IsValid();

        #endregion

        #region Commands

        public ICommand HandleStationCommand { get; private set; }

        #endregion

        #region Services

        private readonly ILocationService _locationService;

        private readonly ITollStationService _tollStationService;

        private readonly ISectionService _sectionService;

        private readonly ISectionInfoService _sectionInfoService;

        private readonly IRoadTollPriceService _roadTollPriceService;

        private readonly IPriceListService _priceListService;

        private readonly IEmployeeService _employeeService;

        #endregion
        public HandleTollStationViewModel(ILocationService locationService, ITollStationService tollStationService,
            ISectionService sectionService, ISectionInfoService sectionInfoService, IRoadTollPriceService roadTollPriceService,
            IPriceListService priceListService, IEmployeeService employeeService,
            TollStationsViewModel tollStationsVM,
            Guid stationId) : base("Add station", 700, 600)
        {
            _locationService = locationService;
            _tollStationService = tollStationService;
            _sectionService = sectionService;
            _sectionInfoService = sectionInfoService;
            _roadTollPriceService = roadTollPriceService;
            _priceListService = priceListService;
            _employeeService = employeeService;

            AllLocations = new ObservableCollection<Location>(_locationService.ReadAll());
            AllSections = new ObservableCollection<Section>(_sectionService.ReadAll());
            AllReferents = new ObservableCollection<Employee>(_employeeService.ReadAll().Where(e => e.Role == Role.Referent));

            _stationId = stationId;

            if (stationId != Guid.Empty)
            {
                FetchProperties();
                Title = "Update station";
                ReadOnlySection = false;
            }
            else
            {
                Title = "Add station";
                ReadOnlySection = true;
            }

            HandleStationCommand = new HandleTollStationCommand(_tollStationService, _sectionService, _sectionInfoService, 
                _roadTollPriceService,
                _priceListService, tollStationsVM, this, _stationId);
        }

        public void ResetFields()
        {
            StationName = null;
            ResetDirtyValues();
            IsValid();
        }

        public void FetchProperties()
        {
            stationToUpdate = _tollStationService.Read(_stationId);
            SelectedLocation = stationToUpdate.Location;
            SelectedReferent = stationToUpdate.Boss;
            SelectedSection = _sectionService.getSectionForTollStation(stationToUpdate.Id);
            var sectionInfo = _sectionInfoService.getSectionInfoForTollStation(stationToUpdate.Id);
            var priceList = _priceListService.GetActivePricelist(SelectedSection);
            Distance = sectionInfo.Distance.ToString();
            Price = _roadTollPriceService.GetBasePriceForTollStation(priceList.Id, stationToUpdate.Id).ToString();
            OrderNumber = stationToUpdate.OrderNumber.ToString();

            StationName = stationToUpdate.Name;
        }


        #region Validation logic

        public bool IsValid()
        {
            bool valid = true;

            // Check if station name is valid
            if (string.IsNullOrEmpty(StationName) && IsDirty(nameof(StationName)))
            {
                StationNameError.ErrorMessage = "Station name cannot be empty.";
                valid = false;
            }
            else
            {
                StationNameError.ErrorMessage = null;
            }

            // Location
            if (SelectedLocation == null && IsDirty(nameof(SelectedLocation)))
            {
                LocationError.ErrorMessage = "You must select a location.";
                valid = false;
            }
            else
            {
                LocationError.ErrorMessage = null;
            }

            // Section
            if (SelectedSection == null && IsDirty(nameof(SelectedSection)))
            {
                SectionError.ErrorMessage = "You must select a section.";
                valid = false;
            }
            else
            {
                SectionError.ErrorMessage = null;
            }

            // Boss
            if (SelectedReferent == null && IsDirty(nameof(SelectedReferent)))
            {
                ReferentError.ErrorMessage = "You must select a referent.";
                valid = false;
            }
            else
            {
                ReferentError.ErrorMessage = null;
            }

            // Distance
            var isNumeric = double.TryParse(Distance, out double distance);
            if (!isNumeric && IsDirty(nameof(Distance)))
            {
                DistanceError.ErrorMessage = "You have to enter a number.";
                valid = false;
            }
            else if (distance < 1 && IsDirty(nameof(Distance)))
            {
                DistanceError.ErrorMessage = "You have to enter a value larger than 0.";
                valid = false;
            }
            else
            {
                DistanceError.ErrorMessage = null;
            }

            // Price
            isNumeric = double.TryParse(Price, out double price);
            if (!isNumeric && IsDirty(nameof(Price)))
            {
                PriceError.ErrorMessage = "You have to enter a number.";
                valid = false;
            }
            else if (price < 1 && IsDirty(nameof(Price)))
            {
                PriceError.ErrorMessage = "You have to enter a value larger than 0.";
                valid = false;
            }
            else
            {
                PriceError.ErrorMessage = null;
            }

            // OrderNumber
            isNumeric = int.TryParse(OrderNumber, out int orderNumber);
            if (!isNumeric && IsDirty(nameof(OrderNumber)))
            {
                OrderNumberError.ErrorMessage = "You have to enter a number.";
                valid = false;
            }
            else if (orderNumber <= 0 && IsDirty(nameof(OrderNumber)))
            {
                OrderNumberError.ErrorMessage = "You have to enter a value larger than 0.";
                valid = false;
            }
            else
            {
                OrderNumberError.ErrorMessage = null;
            }

            return valid && AllDirty();
        }

        #endregion

    }
}
