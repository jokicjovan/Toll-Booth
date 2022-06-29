namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public class ETCPayment : Payment
    {
        #region Properties

        private ElectronicTollCollection _electronicTollCollection;
        public virtual ElectronicTollCollection ElectronicTollCollection { get => _electronicTollCollection; set => OnPropertyChanged(ref _electronicTollCollection, value); }

        #endregion

        #region Constructors

        public ETCPayment() { }

        public ETCPayment(ETCPayment other) : base(other)
        {
            ElectronicTollCollection = other.ElectronicTollCollection;
        }

        #endregion
    }
}
