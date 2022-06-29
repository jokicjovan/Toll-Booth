using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Model
{
    public class SectionInfo : BaseObservableEntity
    {
        #region Properties

        private Section _section;
        public virtual Section Section { get => _section; set => OnPropertyChanged(ref _section, value); }

        private TollStation _tollStation;
        public virtual TollStation TollStation { get => _tollStation; set => OnPropertyChanged(ref _tollStation, value); }

        private double _distance;
        public double Distance { get => _distance; set => OnPropertyChanged(ref _distance, value); }

        #endregion

        #region Constructors

        public SectionInfo() { }

        public SectionInfo(SectionInfo other) : base(other)
        {
            Section = other.Section;
            TollStation = other.TollStation;
            Distance = other.Distance;
        }

        #endregion
    }
}
