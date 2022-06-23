using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public class RoadToll : BaseObservableEntity
    {
        #region Properties

        private TollStation _tollStation;
        public virtual TollStation TollStation { get => _tollStation; set => OnPropertyChanged(ref _tollStation, value); }

        private VehicleType _vehicleType;
        public VehicleType VehicleType { get => _vehicleType; set => OnPropertyChanged(ref _vehicleType, value); }

        private Currency _currency;
        public virtual Currency Currency { get => _currency; set => OnPropertyChanged(ref _currency, value); }

        #endregion

        #region Constructors

        public RoadToll() { }

        public RoadToll(RoadToll other) : base(other)
        {
            TollStation = other.TollStation;
            VehicleType = other.VehicleType;
            Currency = other.Currency;
        }

        #endregion
    }
}
