using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Model
{
    public class TollStation : BaseObservableEntity
    {
        #region Properties

        private string _name;
        public string Name { get => _name; set => OnPropertyChanged(ref _name, value); }

        private Location _location;
        public virtual Location Location { get => _location; set => OnPropertyChanged(ref _location, value); }

        private Referent _boss;
        public virtual Referent Boss { get => _boss; set => OnPropertyChanged(ref _boss, value); }

        private IList<TollBooth> _tollBooths;
        public virtual IList<TollBooth> TollBooths { get => _tollBooths; set => OnPropertyChanged(ref _tollBooths, value); }

        private IList<Employee> _employees;
        public virtual IList<Employee> Employees { get => _employees; set => OnPropertyChanged(ref _employees, value); }

        #endregion

        #region Constructors

        public TollStation() { }

        public TollStation(TollStation other) : base(other)
        {
            Name = other.Name;
            Location = other.Location;
            Boss = other.Boss;
            TollBooths = other.TollBooths;
            Employees = other.Employees;
        }

        #endregion
    }
}
