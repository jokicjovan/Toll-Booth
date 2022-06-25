using System;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public abstract class Payment : BaseObservableEntity
    {
        #region Properties

        private TollBooth _tollBooth;
        public virtual TollBooth TollBooth { get => _tollBooth; set => OnPropertyChanged(ref _tollBooth, value); }

        private TollStation _enterTollStation;
        public virtual TollStation EnterTollStation { get => _enterTollStation; set => OnPropertyChanged(ref _enterTollStation, value); }

        private double _price;
        public double Price { get => _price; set => OnPropertyChanged(ref _price, value); }

        private DateTime _exitTime;
        public virtual DateTime ExitTime { get => _exitTime; set => OnPropertyChanged(ref _exitTime, value); }

        private DateTime _enterTime;
        public DateTime EnterTime { get => _enterTime; set => OnPropertyChanged(ref _enterTime, value); }

        private VehicleType _vehicleType;
        public VehicleType VehicleType { get => _vehicleType; set => OnPropertyChanged(ref _vehicleType, value); }

        private double _distance;
        public double Distance { get => _distance; set => OnPropertyChanged(ref _distance, value); }

        private double _avarageSpeed;
        public double AvarageSpeed { get => _avarageSpeed; set => OnPropertyChanged(ref _avarageSpeed, value); }


        #endregion

        #region Constructors

        public Payment() { }

        public Payment(Payment other) : base(other)
        {
            TollBooth = other.TollBooth;
            EnterTollStation = other.EnterTollStation;
            Price = other.Price;
            Distance = other.Distance;
            AvarageSpeed = other.AvarageSpeed;
            VehicleType = other.VehicleType;
            ExitTime = other.ExitTime;
            EnterTime = other.EnterTime;
        }

        #endregion
    }
}
