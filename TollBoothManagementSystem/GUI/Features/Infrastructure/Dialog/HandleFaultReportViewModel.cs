using System;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.GUI.Features.Navigation;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.Validation;

namespace TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog
{
    public class HandleFaultReportViewModel : DialogViewModelBase<HandleFaultReportViewModel>
    {
        #region Properties
        private string _description;
        [ValidationField]
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); OnPropertyChanged(nameof(CanExecute)); }
        }

        #endregion

        #region Additional properties

        public string Title { get; private set; }
        public string ActionButtonName { get; private set; }

        #endregion

        #region Error message view models
        public ErrorMessageViewModel DescriptionError { get; private set; } = new ErrorMessageViewModel();

        public bool CanExecute => IsValid();

        #endregion

        #region Commands

        public ICommand HandleFaultReportCommand { get; private set; }

        #endregion

        #region Services

        private readonly IFaultReportService _faultReportService;
        private readonly IUserService _userService;
        private readonly ITollBoothService _tollBoothService;

        #endregion
        public HandleFaultReportViewModel(IUserService userService, ITollBoothService tollBoothService, IFaultReportService faultReportService, ReferentHomeViewModel referentHomeVM, FaultType faultType) : base("Fault report", 600, 460)
        {
            if (faultType == FaultType.TrafficLight)
            {
                Title = "Traffic light fault report";
            }
            else
            {
                Title = "Gate fault report";
            }

            ActionButtonName = "Send report";

            _userService = userService;
            _tollBoothService = tollBoothService;
            _faultReportService = faultReportService;

            HandleFaultReportCommand = new HandleFaultReportCommand(_userService, _tollBoothService, _faultReportService, referentHomeVM, this, faultType);
        }

        public void ResetFields()
        {
            Description = null;
            ResetDirtyValues();
            IsValid();
        }

        #region Validation logic
        public bool IsValid()
        {
            bool valid = true;

            // Description
            if (string.IsNullOrEmpty(Description) && IsDirty(nameof(Description)))
            {
                DescriptionError.ErrorMessage = "Description cannot be empty.";
                valid = false;
            }
            else
            {
                DescriptionError.ErrorMessage = null;
            }

            return valid && AllDirty();
        }

        #endregion
    }
}
