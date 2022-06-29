using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Repository
{
    public class SectionInfoRepository : CrudRepository<SectionInfo>, ISectionInfoRepository
    {
        public SectionInfoRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
