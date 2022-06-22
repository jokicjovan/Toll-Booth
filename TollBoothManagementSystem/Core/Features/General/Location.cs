using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.General
{
    public class Location : BaseObservableEntity
    {
        #region Properties

        private int _postalCode;
        public int PostalCode { get => _postalCode; set => OnPropertyChanged(ref _postalCode, value); }

        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        #endregion

        #region Constructors

        public Location() { }

        public Location(Location other) : base(other)
        {
            PostalCode = other.PostalCode;
            Name = other.Name;
        }

        #endregion
    }
}
