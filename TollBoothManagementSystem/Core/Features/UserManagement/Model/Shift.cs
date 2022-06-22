using System;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Model
{
    public class Shift : BaseObservableEntity
    {
        #region Properties

        private TollBooth _tollBooth;
        public virtual TollBooth TollBooth { get => _tollBooth; set => OnPropertyChanged(ref _tollBooth, value); }

        private Referent _referent;
        public virtual Referent Referent { get => _referent; set => OnPropertyChanged(ref _referent, value); }

        private DateTime _start;
        public DateTime Start { get => _start; set => OnPropertyChanged(ref _start, value); }

        private DateTime _end;
        public DateTime End { get => _end; set => OnPropertyChanged(ref _end, value); }

        #endregion

        #region Constructors

        public Shift() { }

        public Shift(Shift other) : base(other)
        {
            TollBooth = other.TollBooth;
            Referent = other.Referent;
            Start = other.Start;
            End = other.End;
        }

        #endregion
    }
}
