using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Service
{
    public interface IEmployeeService : ICrudRepository<Employee>
    {
        public IEnumerable<Employee> getStationEmployees(TollStation tollStation);

        public IEnumerable<Employee> GetEmployeesBySearchText(string searchText);
    }
}