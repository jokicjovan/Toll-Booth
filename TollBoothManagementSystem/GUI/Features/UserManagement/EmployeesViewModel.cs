using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.UserManagement.Commands;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.UserManagement
{
    public class EmployeesViewModel : ViewModelBase
    {
        #region services
        private readonly IEmployeeService _employeeService;

        public IEmployeeService EmployeeService => _employeeService;
        #endregion

        #region attributes
        private IList<Employee> _employees;
        private Employee _selectedEmployee;
        private string _searchText;
        #endregion

        #region properties
        public IList<Employee> Employees {
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
                Employees = _employeeService.GetEmployeesBySearchText(SearchText).ToList<Employee>();
            }
            else
            {
                Employees = _employeeService.ReadAll().ToList<Employee>();
            }
        }

        #endregion

        public EmployeesViewModel(IEmployeeService employeeService) {
            _employeeService = employeeService;

            Employees = EmployeeService.getStationEmployees(GlobalStore.ReadObject<Manager>("LoggedUser").TollStation).ToList();
            SearchEmployeeCommand = new SearchEmployeeCommand(this);
            DeleteEmployeeCommand = new DeleteEmployeeCommand(this);
        }

    }
}
