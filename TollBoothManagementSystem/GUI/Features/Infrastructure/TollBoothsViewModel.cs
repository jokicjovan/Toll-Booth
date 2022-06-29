using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Commands;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Infrastructure
{
    public class TollBoothsViewModel : ViewModelBase, ISearchViewModel
    {
        #region services

        private readonly ITollBoothService _tollBoothService;
        private readonly ITollStationService _tollStationService;
        private readonly IDialogService _dialogService;

        public ITollBoothService TollBoothService => _tollBoothService;
        public ITollStationService TollStationService => _tollStationService;
        public IDialogService DialogService => _dialogService;

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

        public ICommand AddTollBoothCommand { get; set; }

        public ICommand UpdateTollBoothCommand { get; set; }

        public ICommand DeleteTollBoothCommand { get; set; }

        public ICommand SearchTollBoothCommand { get; set; }

        #endregion

        #region methods
        public void Search()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var searchText = SearchText.ToLower();

                TollBooths = new ObservableCollection<TollBooth>(TollStation.TollBooths.Where(tollBooth => tollBooth.Code.ToLower().Contains(searchText)).OrderBy(x => x.Code));
            }
            else
            {
                TollBooths = new ObservableCollection<TollBooth>(TollStation.TollBooths.OrderBy(x => x.Code));
            }
        }

        #endregion

        public TollBoothsViewModel(ITollBoothService tollBoothService, ITollStationService tollStationService, IDialogService dialogService, Guid tollStationId)
        {
            _tollBoothService = tollBoothService;
            _tollStationService = tollStationService;
            _dialogService = dialogService;

            _tollStation = _tollStationService.Read(tollStationId);
            Search();

            AddTollBoothCommand = new AddTollBoothCommand(_dialogService, this, _tollStation);
            UpdateTollBoothCommand = new UpdateTollBoothCommand(_dialogService, this, _tollStation);
            SearchTollBoothCommand = new SearchCommand(this);
            DeleteTollBoothCommand = new DeleteTollBoothCommand(this);
        }
    }
}
