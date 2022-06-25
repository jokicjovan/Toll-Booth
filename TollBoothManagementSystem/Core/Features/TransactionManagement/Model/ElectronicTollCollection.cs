using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public class ElectronicTollCollection : BaseObservableEntity
    {
        #region Properties

        private string _licencePlateNumber;
        public string LicencePlateNumber { get => _licencePlateNumber; set => OnPropertyChanged(ref _licencePlateNumber, value); }

        private double _credit;
        public double Credit { get => _credit; set => OnPropertyChanged(ref _credit, value); }

        #endregion

        #region Constructors

        public ElectronicTollCollection() { }

        public ElectronicTollCollection(ElectronicTollCollection other) : base(other)
        {
            LicencePlateNumber = other.LicencePlateNumber;
            Credit = other.Credit;
        }

        #endregion
    }
}
