using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Repository
{
    public class RoadTollRepository : CrudRepository<RoadToll>, IRoadTollRepository
    {
        public RoadTollRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
