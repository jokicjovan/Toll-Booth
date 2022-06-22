using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public class Section : BaseObservableEntity
    {
        #region Properties

        private TollStation _origin;
        public TollStation Origin { get => _origin; set => OnPropertyChanged(ref _origin, value); }

        private TollStation _destination;
        public TollStation Destination { get => _destination; set => OnPropertyChanged(ref _destination, value); }

        #endregion

        #region Constructors

        public Section() { }

        public Section(Section other) : base(other)
        {
            Origin = other.Origin;
            Destination = other.Destination;
        }

        #endregion

    }
}
