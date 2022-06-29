using System.Text.RegularExpressions;
using System.Windows.Input;
using System;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.Validation;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using System.Collections.ObjectModel;
using TollBoothManagementSystem.Core.Features.UserManagement.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;

namespace TollBoothManagementSystem.GUI.Features.UserManagement.Dialog
{
    public class HandleEmployeeViewModel : DialogViewModelBase<HandleEmployeeViewModel>
    {
        #region Properties

        private string _emailAddress;
        [ValidationField]
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; OnPropertyChanged(nameof(EmailAddress)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private string _firstName;
        [ValidationField]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private string _lastName;
        [ValidationField]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private string _password;
        [ValidationField]
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private string _confirmPassword;
        [ValidationField]
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; OnPropertyChanged(nameof(ConfirmPassword)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private DateTime _dateOfBirth = DateTime.Now;
        [ValidationField]
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private Role? _chosenRole;
        [ValidationField]
        public Role? ChosenRole
        {
            get { return _chosenRole; }
            set { _chosenRole = value; OnPropertyChanged(nameof(ChosenRole)); OnPropertyChanged(nameof(CanExecute)); }
        }

        #endregion

        #region Additional properties

        public ObservableCollection<Role> _availableRoles;
        public ObservableCollection<Role> AvailableRoles
        {
            get { return _availableRoles; }
            set { _availableRoles = value; OnPropertyChanged(nameof(AvailableRoles)); OnPropertyChanged(nameof(CanExecute)); }
        }

        public bool ReadOnlyEmailAddress { get; private set; }

        private Guid _employeeId;

        public string Title { get; private set; }
        public string ActionButtonName { get; private set; }

        #endregion

        #region Error message view models

        private static readonly Regex _emailregex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

        public ErrorMessageViewModel FirstNameError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel LastNameError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel EmailAddressError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel PasswordError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel ConfirmPasswordError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel DateOfBirthError { get; private set; } = new ErrorMessageViewModel();

        public bool CanExecute => IsValid();

        #endregion

        #region Commands

        public ICommand HandleEmployeeCommand { get; private set; }

        #endregion

        #region Services

        private readonly IUserService _userService;
        private readonly ITollStationService _tollStationService;

        #endregion
        public HandleEmployeeViewModel(IUserService userService, ITollStationService tollStationService, EmployeesViewModel employeesVM,
            Guid employeeId, TollStation tollStation) : base("Add employee", 700, 550)
        {
            _userService = userService;
            _employeeId = employeeId;
            _tollStationService = tollStationService;

            AvailableRoles = new ObservableCollection<Role> { Role.Referent, Role.Manager };

            if (employeeId != Guid.Empty)
            {
                FetchEmployee();
                Title = "Update employee";
                ActionButtonName = "Update";
                ReadOnlyEmailAddress = true;
            }
            else
            {
                Title = "Add employee";
                ActionButtonName = "Add";
                ReadOnlyEmailAddress = false;
            }

            HandleEmployeeCommand = new HandleEmployeeCommand(_userService, _tollStationService, employeesVM, this, employeeId, tollStation);
        }

        public void ResetFields()
        {
            EmailAddress = null;
            FirstName = null;
            LastName = null;
            Password = null;
            ConfirmPassword = null;
            DateOfBirth = DateTime.Now;
            ResetDirtyValues();
            IsValid();
        }

        public void FetchEmployee()
        {
            var employee = _userService.Read(_employeeId);

            EmailAddress = employee.EmailAddress;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Password = employee.Password;
            ConfirmPassword = employee.Password;
            DateOfBirth = employee.DateOfBirth;
            ChosenRole = employee.Role;

        }

        #region Validation logic
        public bool IsValid()
        {
            bool valid = true;

            // Check if email is valid
            if (string.IsNullOrEmpty(EmailAddress) && IsDirty(nameof(EmailAddress)))
            {
                EmailAddressError.ErrorMessage = "Email cannot be empty.";
                valid = false;
            }
            else if (!string.IsNullOrEmpty(EmailAddress) && !_emailregex.IsMatch(EmailAddress))
            {
                EmailAddressError.ErrorMessage = "Email is not in correct format.";
                valid = false;
            }
            else
            {
                EmailAddressError.ErrorMessage = null;
            }

            // First name
            if (string.IsNullOrEmpty(FirstName) && IsDirty(nameof(FirstName)))
            {
                FirstNameError.ErrorMessage = "First name cannot be empty.";
                valid = false;
            }
            else
            {
                FirstNameError.ErrorMessage = null;
            }

            // Last name
            if (string.IsNullOrEmpty(LastName) && IsDirty(nameof(LastName)))
            {
                LastNameError.ErrorMessage = "Last name cannot be empty.";
                valid = false;
            }
            else
            {
                LastNameError.ErrorMessage = null;
            }

            // Password
            if (string.IsNullOrEmpty(Password) && IsDirty(nameof(Password)))
            {
                PasswordError.ErrorMessage = "Password cannot be empty.";
                valid = false;
            }
            else
            {
                PasswordError.ErrorMessage = null;
            }

            // Confirm password
            if (ConfirmPassword != Password && IsDirty(nameof(ConfirmPassword)))
            {
                ConfirmPasswordError.ErrorMessage = "Password and confirm password must match.";
                valid = false;
            }
            else
            {
                ConfirmPasswordError.ErrorMessage = null;
            }

            // Date of birth
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age))
            {
                age--;
            }
            if (age < 18 && IsDirty(nameof(DateOfBirth)))
            {
                DateOfBirthError.ErrorMessage = "Employee must be at least 18 years old in order to be registered.";
                valid = false;
            }
            else
            {
                DateOfBirthError.ErrorMessage = null;
            }

            return valid && AllDirty();
        }

        #endregion
    }
}
