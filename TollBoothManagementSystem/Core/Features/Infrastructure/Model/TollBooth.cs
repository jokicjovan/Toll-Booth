using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Model
{
    public class TollBooth : BaseObservableEntity
    {
        #region Properties

        private bool _isETC;
        public bool IsETC { get => _isETC; set => OnPropertyChanged(ref _isETC, value); }

        private bool _isOpen;
        public bool IsOpen { get => _isOpen; set => OnPropertyChanged(ref _isOpen, value); }

        private TollStation _tollStation;
        public virtual TollStation TollStation { get => _tollStation; set => OnPropertyChanged(ref _tollStation, value); }

        #endregion

        #region Constructors

        public TollBooth() { }

        public TollBooth(TollBooth other) : base(other)
        {
            IsETC = other.IsETC;
            IsOpen = other.IsOpen;
            TollStation = other.TollStation;
        }

        #endregion
    }
}
