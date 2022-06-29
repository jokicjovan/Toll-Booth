using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.Infrastructure.Commands.Dialog;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.Validation;

namespace TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog
{
    public class HandleTollBoothViewModel : DialogViewModelBase<HandleTollBoothViewModel>
    {
        #region Properties

        private string _boothCode;
        [ValidationField]
        public string BoothCode
        {
            get { return _boothCode; }
            set { _boothCode = value; OnPropertyChanged(nameof(BoothCode)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private bool? _isETC;
        [ValidationField]
        public bool? IsETC
        {
            get { return _isETC; }
            set { _isETC = value; OnPropertyChanged(nameof(IsETC)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private bool? _isOpen;
        [ValidationField]
        public bool? IsOpen
        {
            get { return _isOpen; }
            set { _isOpen = value; OnPropertyChanged(nameof(IsOpen)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private bool? _isTrafficLightFunctional;
        [ValidationField]
        public bool? IsTrafficLightFunctional
        {
            get { return _isTrafficLightFunctional; }
            set { _isTrafficLightFunctional = value; OnPropertyChanged(nameof(IsTrafficLightFunctional)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private bool? _isTollGateFunctional;
        [ValidationField]
        public bool? IsTollGateFunctional
        {
            get { return _isTollGateFunctional; }
            set { _isTollGateFunctional = value; OnPropertyChanged(nameof(IsTollGateFunctional)); OnPropertyChanged(nameof(CanExecute)); }
        }

        private ObservableCollection<bool> _booleans;
        public ObservableCollection<bool> Booleans
        {
            get { return _booleans; }
            set { _booleans = value; OnPropertyChanged(nameof(Booleans)); OnPropertyChanged(nameof(CanExecute)); }
        }

        #endregion

        #region Additional properties

        private Guid _boothId;

        public TollBooth? tollBoothToUpdate;

        #endregion

        #region Error message view models

        public ErrorMessageViewModel BoothCodeError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel IsETCError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel IsOpenError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel IsTrafficLightFunctionalError { get; private set; } = new ErrorMessageViewModel();
        public ErrorMessageViewModel IsTollGateFunctionalError { get; private set; } = new ErrorMessageViewModel();


        public bool CanExecute => IsValid();

        #endregion

        #region Commands

        public ICommand HandleBoothCommand { get; private set; }

        #endregion

        #region Services

        private readonly ITollBoothService _tollBoothService;

        private readonly ITollStationService _tollStationService;

        #endregion
        public HandleTollBoothViewModel(ITollBoothService tollBoothService, ITollStationService tollStationService,
            TollBoothsViewModel tollBoothsVm,
            Guid boothId, TollStation tollStation) : base("Add station", 700, 500)
        {
            _tollBoothService = tollBoothService;
            _tollStationService = tollStationService;

            _boothId = boothId;

            Booleans = new ObservableCollection<bool>() { true, false };

            if (_boothId != Guid.Empty)
            {
                FetchProperties();
                Title = "Update booth";
            }
            else
            {
                Title = "Add booth";
            }

            HandleBoothCommand = new HandleTollBoothCommand(_tollBoothService, _tollStationService,  tollBoothsVm, this, boothId, tollStation);
        }

        public void ResetFields()
        {
            BoothCode = null;
            ResetDirtyValues();
            IsValid();
        }

        public void FetchProperties()
        {
            tollBoothToUpdate = _tollBoothService.Read(_boothId);
            BoothCode = tollBoothToUpdate.Code;
            IsETC = tollBoothToUpdate.IsETC;
            IsOpen = tollBoothToUpdate.IsOpen;
            IsTrafficLightFunctional = tollBoothToUpdate.IsTrafficLightFunctional;
            IsTollGateFunctional = tollBoothToUpdate.IsTollGateFunctional;
        }


        #region Validation logic

        public bool IsValid()
        {
            bool valid = true;

            // Check if booth code is valid
            if (string.IsNullOrEmpty(BoothCode) && IsDirty(nameof(BoothCode)))
            {
                BoothCodeError.ErrorMessage = "Booth code cannot be empty.";
                valid = false;
            }
            else
            {
                BoothCodeError.ErrorMessage = null;
            }

            // IsETC
            if (IsETC == null && IsDirty(nameof(IsETC)))
            {
                IsETCError.ErrorMessage = "You must select a value.";
                valid = false;
            }
            else
            {
                IsETCError.ErrorMessage = null;
            }

            // IsOpen
            if (IsOpen == null && IsDirty(nameof(IsOpen)))
            {
                IsOpenError.ErrorMessage = "You must select a value.";
                valid = false;
            }
            else
            {
                IsOpenError.ErrorMessage = null;
            }

            // IsTrafficLightFunctional
            if (IsTrafficLightFunctional == null && IsDirty(nameof(IsOpen)))
            {
                IsTrafficLightFunctionalError.ErrorMessage = "You must select a value.";
                valid = false;
            }
            else
            {
                IsTrafficLightFunctionalError.ErrorMessage = null;
            }

            // IsTollGateFunctional
            if (IsTollGateFunctional == null && IsDirty(nameof(IsTollGateFunctional)))
            {
                IsTollGateFunctionalError.ErrorMessage = "You must select a value.";
                valid = false;
            }
            else
            {
                IsTollGateFunctionalError.ErrorMessage = null;
            }

            return valid && AllDirty();
        }

        #endregion

    }
}
