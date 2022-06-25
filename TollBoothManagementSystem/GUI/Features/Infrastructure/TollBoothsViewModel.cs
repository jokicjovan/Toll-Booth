using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Infrastructure
{
    public class TollBoothsViewModel : ViewModelBase
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
                OnPropertyChanged(nameof(_tollBooths));
            }
        }

        public TollBooth SelectedTollBooth
        {
            get => _selectedTollBooth;
            set
            {
                _selectedTollBooth = value;
                OnPropertyChanged(nameof(_selectedTollBooth));
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

        public ICommand AddEmployeeCommand { get; set; }

        public ICommand UpdateEmployeeCommand { get; set; }

        public ICommand DeleteEmployeeCommand { get; set; }

        public ICommand SearchEmployeeCommand { get; set; }

        public ICommand Return { get; set; }

        #endregion

        #region methods
        public void SearchEmployee()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var searchText = SearchText.ToLower();
                var roles = Enum.GetValues(typeof(Role)).Cast<Role>().Where(text => Enum.GetName(typeof(Role), text).ToLower().Contains(searchText));

                //Employees = new ObservableCollection<Employee>(TollStation.Employees.Where(employee => employee.FirstName.ToLower().Contains(searchText)
               //|| employee.LastName.ToLower().Contains(searchText) || roles.Contains(employee.Role)));
            }
            else
            {
                //Employees = new ObservableCollection<Employee>(TollStation.Employees);
            }
        }

        #endregion

        public TollBoothsViewModel(ITollBoothService tollBoothService, ITollStationService tollStationService, IDialogService dialogService, Guid tollStationId)
        {
            _tollBoothService = tollBoothService;
            _tollStationService = tollStationService;
            _dialogService = dialogService;

            _tollStation = _tollStationService.Read(tollStationId);
            TollBooths = new ObservableCollection<TollBooth>(_tollStation.TollBooths);
        }

        void InitiateCommands()
        {
            //AddEmployeeCommand = new AddEmployeeCommand(_dialogService, this);
            //UpdateEmployeeCommand = new UpdateEmployeeCommand(_dialogService, this);
            //SearchEmployeeCommand = new SearchEmployeeCommand(this);
            //DeleteEmployeeCommand = new DeleteEmployeeCommand(this);
        }
    }
}
