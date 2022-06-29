using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Repository
{
    public class FaultReportRepository : CrudRepository<FaultReport>, IFaultReportRepository
    {
        public FaultReportRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
