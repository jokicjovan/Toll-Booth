using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Infrastructure
{
    public class FixTollBoothViewModel : ViewModelBase, ISearchViewModel
    {
        #region services

        private readonly ITollBoothService _tollBoothService;
        private readonly ITollStationService _tollStationService;

        public ITollBoothService TollBoothService => _tollBoothService;
        public ITollStationService TollStationService => _tollStationService;

        #endregion

        #region attributes

        private ObservableCollection<TollBooth> _tollBooths;

        private TollBooth _selectedTollBooth;

        private string _searchText;

        private TollStation _tollStation;

        #endregion

        #region properties

        public ObservableCollection<TollBooth> TollBooths
        {
            get => _tollBooths;
            set
            {
                _tollBooths = value;
                OnPropertyChanged(nameof(TollBooths));
            }
        }

        public TollBooth SelectedTollBooth
        {
            get => _selectedTollBooth;
            set
            {
                _selectedTollBooth = value;
                OnPropertyChanged(nameof(SelectedTollBooth));
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
        public TollStation TollStation
        {
            get => _tollStation;
            set
            {
                _tollStation = value;
                OnPropertyChanged(nameof(TollStation));
            }
        }

        #endregion

        #region commands

        public ICommand SearchTollBoothCommand { get; set; }
        public ICommand FixTrafficLightCommand { get; set; }
        public ICommand FixGateCommand { get; set; }

        #endregion

        #region methods
        public void Search()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var searchText = SearchText.ToLower();

                TollBooths = new ObservableCollection<TollBooth>(TollStation.TollBooths.Where(tollBooth => tollBooth.Code.ToLower().Contains(searchText)));
            }
            else
            {
                TollBooths = new ObservableCollection<TollBooth>(TollStation.TollBooths);
            }
        }

        #endregion

        public FixTollBoothViewModel(ITollBoothService tollBoothService, ITollStationService tollStationService)
        {
            _tollBoothService = tollBoothService;
            _tollStationService = tollStationService;

            _tollStation = _tollStationService.Read(GlobalStore.ReadObject<Manager>("LoggedUser").TollStation.Id);
            TollBooths = new ObservableCollection<TollBooth>(_tollStation.TollBooths);

            SearchTollBoothCommand = new SearchCommand(this);
            FixTrafficLightCommand = new FixTrafficLightCommand(this);
            FixGateCommand = new FixGateCommand(this);
        }
    }
}
