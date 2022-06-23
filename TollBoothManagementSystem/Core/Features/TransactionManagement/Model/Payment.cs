using System;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public abstract class Payment : BaseObservableEntity
    {
        #region Properties

        private TollBooth _tollBooth;
        public virtual TollBooth TollBooth { get => _tollBooth; set => OnPropertyChanged(ref _tollBooth, value); }

        private RoadTollPrice _roadTollPrice;
        public virtual RoadTollPrice RoadTollPrice { get => _roadTollPrice; set => OnPropertyChanged(ref _roadTollPrice, value); }

        private DateTime _exitTime;
        public virtual DateTime ExitTime { get => _exitTime; set => OnPropertyChanged(ref _exitTime, value); }

        private DateTime _enterTime;
        public DateTime EnterTime { get => _enterTime; set => OnPropertyChanged(ref _enterTime, value); }

        #endregion

        #region Constructors

        public Payment() { }

        public Payment(Payment other) : base(other)
        {
            TollBooth = other.TollBooth;
            RoadTollPrice = other.RoadTollPrice;
            ExitTime = other.ExitTime;
            EnterTime = other.EnterTime;
        }

        #endregion
    }
}
