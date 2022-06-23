using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Repository
{
    public class PriceListRepository : CrudRepository<PriceList>, IPriceListRepository
    {
        public PriceListRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
