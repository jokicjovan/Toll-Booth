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
