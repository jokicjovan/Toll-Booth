using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Repository
{
    public class SectionRepository : CrudRepository<Section>, ISectionRepository
    {
        public SectionRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
