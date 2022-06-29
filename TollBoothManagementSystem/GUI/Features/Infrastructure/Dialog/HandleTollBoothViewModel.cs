using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.GUI.Utility.Dialog;
using TollBoothManagementSystem.GUI.Utility.Validation;

namespace TollBoothManagementSystem.GUI.Features.Infrastructure.Dialog
{
    public class HandleTollBoothViewModel : DialogViewModelBase<HandleTollStationViewModel>
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
            TollStationsViewModel tollStationsVM,
            Guid boothId) : base("Add station", 700, 600)
        {
            _tollBoothService = tollBoothService;
            _tollStationService = tollStationService;

            _boothId = boothId;

            if (_boothId != Guid.Empty)
            {
                FetchProperties();
                Title = "Update booth";
            }
            else
            {
                Title = "Add booth";
            }

            HandleStationCommand = new HandleTollStationCommand(_tollStationService, _sectionService, _sectionInfoService,
                _roadTollPriceService,
                _priceListService, tollStationsVM, this, _stationId);
        }

        public void ResetFields()
        {
            StationName = null;
            ResetDirtyValues();
            IsValid();
        }

        public void FetchProperties()
        {
            stationToUpdate = _tollStationService.Read(_stationId);
            SelectedLocation = stationToUpdate.Location;
            SelectedReferent = stationToUpdate.Boss;
            SelectedSection = _sectionService.getSectionForTollStation(stationToUpdate.Id);
            var sectionInfo = _sectionInfoService.getSectionInfoForTollStation(stationToUpdate.Id);
            var priceList = _priceListService.GetActivePricelist(SelectedSection);
            Distance = sectionInfo.Distance.ToString();
            Price = _roadTollPriceService.GetBasePriceForTollStation(priceList.Id, stationToUpdate.Id).ToString();
            OrderNumber = stationToUpdate.OrderNumber.ToString();

            StationName = stationToUpdate.Name;
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
                IsOpenError.ErrorMessage = "You must select a value.";
                valid = false;
            }
            else
            {
                IsOpenError.ErrorMessage = null;
            }

            return valid && AllDirty();
        }

        #endregion

    }
}
