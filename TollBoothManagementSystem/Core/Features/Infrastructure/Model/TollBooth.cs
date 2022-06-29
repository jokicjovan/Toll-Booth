using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Model
{
    public class TollBooth : BaseObservableEntity
    {
        #region Properties

        private string _code;
        public string Code { get => _code; set => OnPropertyChanged(ref _code, value); }

        private bool _isETC;
        public bool IsETC { get => _isETC; set => OnPropertyChanged(ref _isETC, value); }

        private bool _isOpen;
        public bool IsOpen { get => _isOpen; set => OnPropertyChanged(ref _isOpen, value); }

        private bool _isTrafficLightFunctional;
        public bool IsTrafficLightFunctional { get => _isTrafficLightFunctional; set => OnPropertyChanged(ref _isTrafficLightFunctional, value); }

        private bool _isTollGateFunctional;
        public bool IsTollGateFunctional { get => _isTollGateFunctional; set => OnPropertyChanged(ref _isTollGateFunctional, value); }

        private TollStation? _tollStation;
        public virtual TollStation? TollStation { get => _tollStation; set => OnPropertyChanged(ref _tollStation, value); }

        #endregion

        #region Constructors

        public TollBooth() { }

        public TollBooth(TollBooth other) : base(other)
        {
            IsETC = other.IsETC;
            IsOpen = other.IsOpen;
            IsTrafficLightFunctional = other.IsTrafficLightFunctional;
            IsTollGateFunctional = other.IsTollGateFunctional;
            TollStation = other.TollStation;
        }

        #endregion
    }
}
