using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.General
{
    public class Currency : BaseObservableEntity
    {
        #region Properties

        private string _code;
        public string Code { get => _code; set => OnPropertyChanged(ref _code, value); }

        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        #endregion

        #region Constructors

        public Currency() { }

        public Currency(Currency other) : base(other)
        {
            Code = other.Code;
            Name = other.Name;
        }

        #endregion
    }
}
