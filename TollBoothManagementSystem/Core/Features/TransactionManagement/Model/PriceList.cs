using System;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public class PriceList : BaseObservableEntity
    {
        #region Properties

        private DateTime _activationDate;
        public DateTime ActivationDate { get => _activationDate; set => OnPropertyChanged(ref _activationDate, value); }

        private DateTime _expirationDate;
        public DateTime ExpirationDate { get => _expirationDate; set => OnPropertyChanged(ref _expirationDate, value); }

        private Section _section;
        public virtual Section Section { get => _section; set => OnPropertyChanged(ref _section, value); }

        #endregion

        #region Constructors

        public PriceList() { }

        public PriceList(PriceList other) : base(other)
        {
            ActivationDate = other.ActivationDate;
            ExpirationDate = other.ExpirationDate;
            Section = other.Section;
        }

        #endregion
    }
}
