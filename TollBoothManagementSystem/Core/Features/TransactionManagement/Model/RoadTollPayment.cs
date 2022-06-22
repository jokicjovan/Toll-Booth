namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public class RoadTollPayment : Payment
    {
        #region Properties

        private string _licencePlateNumber;
        public string LicencePlateNumber { get => _licencePlateNumber; set => OnPropertyChanged(ref _licencePlateNumber, value); }

        #endregion

        #region Constructors

        public RoadTollPayment() { }

        public RoadTollPayment(RoadTollPayment other) : base(other)
        {
            LicencePlateNumber = other.LicencePlateNumber;
        }

        #endregion
    }
}
