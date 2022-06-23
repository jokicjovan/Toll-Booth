using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Repository
{
    public class ElectronicTollCollectionRepository : CrudRepository<ElectronicTollCollection>, IElectronicTollCollectionRepository
    {
        public ElectronicTollCollectionRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
