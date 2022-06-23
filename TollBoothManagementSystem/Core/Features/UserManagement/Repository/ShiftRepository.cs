using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Repository
{
    public class ShiftRepository : CrudRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
