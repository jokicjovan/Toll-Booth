using System;
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

        public override Employee Delete(Guid id)
        {
            var entityToDelete = Read(id);
            if (entityToDelete != null)
            {
                entityToDelete.IsActive = false;
                entityToDelete.TollStation = null;
                Update(entityToDelete);
            }

            return entityToDelete;
        }
    }
}
