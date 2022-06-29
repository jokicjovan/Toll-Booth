using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Repository
{
    public class PaymentRepository : CrudRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
