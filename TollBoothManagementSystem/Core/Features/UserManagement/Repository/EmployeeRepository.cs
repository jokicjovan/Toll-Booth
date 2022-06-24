using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Repository
{
    public class EmployeeRepository : CrudRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
