using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Repository
{
    public class RoadTollPriceRepository : CrudRepository<RoadTollPrice>, IRoadTollPriceRepository
    {
        public RoadTollPriceRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
