using TollBoothManagementSystem.Core.Features.Infrastructure.Model;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Model
{
    public class Employee : User
    {

        #region Properties
        private TollStation? _tollStation;
        public virtual TollStation? TollStation { get => _tollStation; set => OnPropertyChanged(ref _tollStation, value); }
        #endregion


        #region Constructors

        public Employee() { }

        public Employee(Employee other) : base(other)
        {

        }

        #endregion
    }
}
