using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public class RoadTollPrice : BaseObservableEntity
    {
        #region Properties

        private PriceList _priceList;
        public virtual PriceList PriceList { get => _priceList; set => OnPropertyChanged(ref _priceList, value); }

        private RoadToll _roadToll;
        public virtual RoadToll RoadToll { get => _roadToll; set => OnPropertyChanged(ref _roadToll, value); }

        private double _price;
        public double Price { get => _price; set => OnPropertyChanged(ref _price, value); }

        #endregion

        #region Constructors

        public RoadTollPrice() { }

        public RoadTollPrice(RoadTollPrice other) : base(other)
        {
            PriceList = other.PriceList;
            RoadToll = other.RoadToll;
            Price = other.Price;
        }

        #endregion
    }
}
