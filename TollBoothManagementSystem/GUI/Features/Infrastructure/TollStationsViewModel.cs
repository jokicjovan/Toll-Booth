using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Infrastructure
{
    public class TollStationsViewModel : ViewModelBase
    {
        #region services
        private readonly ITollStationService _tollStationService;
        private readonly IDialogService _dialogService;

        public IDialogService DialogService => _dialogService;
        public ITollStationService TollStationService => _tollStationService;

        #endregion

        #region attributes

        private ObservableCollection<TollStation> _tollStations;

        private TollStation _selectedTollStation;

        private string _searchText;

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

        #endregion

        #region methods
        public void SearchTollStation()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var searchText = SearchText.ToLower();
                TollStations = new ObservableCollection<TollStation>(TollStationService.ReadAll().Where(tollStation => tollStation.Name.ToLower().Contains(searchText)
               || tollStation.Location.Name.ToLower().Contains(searchText) || (tollStation.Boss != null && tollStation.Boss.FullName.ToLower().Contains(searchText))));
            }
            else
            {
                TollStations = new ObservableCollection<TollStation>(TollStationService.ReadAll());
            }
        }

        #endregion

        public TollStationsViewModel(ITollStationService tollStationService, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _tollStationService = tollStationService;

            _tollStations = new ObservableCollection<TollStation>(TollStationService.ReadAll());
            //AddTollStationCommand = new AddTollStationCommand(_dialogService, this);
            //UpdateTollStationCommand = new UpdateTollStationCommand(_dialogService, this);
            //DeleteTollStationCommand = new DeleteTollStationCommand(this);
            ShowTollBoothsCommand = new ShowTollBoothsCommand(this);
            //SearchTollStationCommand = new SearchTollStationCommand(this);
        }
    }
}
