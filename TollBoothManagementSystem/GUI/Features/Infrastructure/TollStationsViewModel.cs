using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Infrastructure
{
    public class TollStationsViewModel : ViewModelBase, ISearchViewModel
    {
        #region services
        private readonly IEmployeeService _employeeService;
        private readonly ITollStationService _tollStationService;
        private readonly ISectionService _sectionService;
        private readonly IDialogService _dialogService;

        public IEmployeeService EmployeeService => _employeeService;
        public IDialogService DialogService => _dialogService;
        public ISectionService SectionService => _sectionService;
        public ITollStationService TollStationService => _tollStationService;

        #endregion

        #region attributes

        private ObservableCollection<TollStation> _tollStations;

        private TollStation _selectedTollStation;

        private string _searchText;

        private ObservableCollection<Section> _sections;

        private Section _selectedSection;

        #endregion

        #region properties

        public ObservableCollection<TollStation> TollStations
        {
            get => _tollStations;
            set
            {
                _tollStations = value;
                OnPropertyChanged(nameof(TollStations));
            }
        }

        public TollStation SelectedTollStation
        {
            get => _selectedTollStation;
            set
            {
                _selectedTollStation = value;
                OnPropertyChanged(nameof(SelectedTollStation));
            }
        }

        public ObservableCollection<Section> Sections
        {
            get => _sections;
            set
            {
                _sections = value;
                OnPropertyChanged(nameof(Sections));
            }
        }

        public Section SelectedSection
        {
            get => _selectedSection;
            set
            {
                _selectedSection = value;
                SelectedTollStation = null;
                TollStations = new ObservableCollection<TollStation>(_selectedSection.TollStations.OrderBy(x => x.OrderNumber).ThenBy(x => x.Name));
                OnPropertyChanged(nameof(SelectedSection));
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        #endregion

        #region commands

        public ICommand AddTollStationCommand { get; set; }

        public ICommand UpdateTollStationCommand { get; set; }

        public ICommand DeleteTollStationCommand { get; set; }

        public ICommand SearchTollStationCommand { get; set; }

        public ICommand ShowTollBoothsCommand { get; set; }

        public ICommand ShowEmployeesCommand { get; set; }

        #endregion

        #region methods
        public void Search()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var searchText = SearchText.ToLower();
                TollStations = new ObservableCollection<TollStation>(_selectedSection.TollStations.Where(tollStation => tollStation.Name.ToLower().Contains(searchText)
               || tollStation.Location.Name.ToLower().Contains(searchText)).OrderBy(x => x.OrderNumber).ThenBy(x => x.Name));
            }
            else
            {
                TollStations = new ObservableCollection<TollStation>(_selectedSection.TollStations.OrderBy(x => x.OrderNumber).ThenBy(x => x.Name));
            }
        }

        #endregion

        public TollStationsViewModel(IEmployeeService employeeService, ITollStationService tollStationService, ISectionService sectionService, IDialogService dialogService)
        {
            _employeeService = employeeService;
            _dialogService = dialogService;
            _tollStationService = tollStationService;
            _sectionService = sectionService;

            _sections = new ObservableCollection<Section>(SectionService.ReadAll());
            SelectedSection = _sections.FirstOrDefault();

            AddTollStationCommand = new AddTollStationCommand(_dialogService, this);
            //UpdateTollStationCommand = new UpdateTollStationCommand(_dialogService, this);
            ShowEmployeesCommand = new OpenAllEmployeesManagementCommand(this);
            ShowTollBoothsCommand = new ShowTollBoothsCommand(this);
            DeleteTollStationCommand = new DeleteTollStationCommand(this);
            SearchTollStationCommand = new SearchCommand(this);
        }
    }
}
