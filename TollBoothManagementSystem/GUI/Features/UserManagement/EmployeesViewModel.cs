using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.UserManagement
{
    public class EmployeesViewModel : ViewModelBase
    {
        #region services

        private readonly IEmployeeService _employeeService;
        private readonly ITollStationService _tollStationService;
        private readonly IDialogService _dialogService;

        public IEmployeeService EmployeeService => _employeeService;
        public IDialogService DialogService => _dialogService;
        public ITollStationService TollStationService => _tollStationService;

        #endregion

        #region attributes

        private ObservableCollection<Employee> _employees;

        private Employee _selectedEmployee;

        private string _searchText;

        private TollStation _tollStation;

        #endregion

        #region properties

        public ObservableCollection<Employee> Employees {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
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

        #endregion

        #region methods
        public void SearchEmployee()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var searchText = SearchText.ToLower();
                var roles = Enum.GetValues(typeof(Role)).Cast<Role>().Where(text => Enum.GetName(typeof(Role), text).ToLower().Contains(searchText));

                Employees = new ObservableCollection<Employee>(TollStation.Employees.Where(employee => employee.FirstName.ToLower().Contains(searchText)
               || employee.LastName.ToLower().Contains(searchText) || roles.Contains(employee.Role)));
            }
            else
            {
                Employees = new ObservableCollection<Employee>(TollStation.Employees);
            }
        }

        #endregion

        public EmployeesViewModel(IEmployeeService employeeService, ITollStationService tollStationService, IDialogService dialogService) {
            _employeeService = employeeService;
            _dialogService = dialogService;
            _tollStationService = tollStationService;

            _tollStation = GlobalStore.ReadObject<Manager>("LoggedUser").TollStation;
            Employees = new ObservableCollection<Employee>(TollStation.Employees);
            AddEmployeeCommand = new AddEmployeeCommand(_dialogService, this);
            UpdateEmployeeCommand = new UpdateEmployeeCommand(_dialogService, this);
            SearchEmployeeCommand = new SearchEmployeeCommand(this);
            DeleteEmployeeCommand = new DeleteEmployeeCommand(this);
        }

    }
}
