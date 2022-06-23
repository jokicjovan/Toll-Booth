using System;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Model
{
    public class FaultReport : BaseObservableEntity
    {
        #region Properties

        private string _description;
        public string Description { get => _description; set => OnPropertyChanged(ref _description, value); }

        private TollBooth _tollBooth;
        public virtual TollBooth TollBooth { get => _tollBooth; set => OnPropertyChanged(ref _tollBooth, value); }

        private Referent _reporter;
        public virtual Referent Reporter { get => _reporter; set => OnPropertyChanged(ref _reporter, value); }

        private DateTime _dateOfReport;
        public DateTime DateOfReport { get => _dateOfReport; set => OnPropertyChanged(ref _dateOfReport, value); }

        #endregion

        #region Constructors

        public FaultReport() { }

        public FaultReport(FaultReport other) : base(other)
        {
            Description = other.Description;
            TollBooth = other.TollBooth;
            Reporter = other.Reporter;
            DateOfReport = other.DateOfReport;
        }

        #endregion
    }
}
