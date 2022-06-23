using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Repository
{
    public class RoadTollPaymentRepository : CrudRepository<RoadTollPayment>, IRoadTollPaymentRepository
    {
        public RoadTollPaymentRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
