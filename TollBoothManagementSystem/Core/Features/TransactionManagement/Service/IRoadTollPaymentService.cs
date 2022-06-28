using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public interface IRoadTollPaymentService : ICrudRepository<RoadTollPayment>
    {
        IEnumerable<RoadTollPayment> GetPaymentsForStation(TollStation tollStation);
        IEnumerable<RoadTollPayment> GetPaymentsForBooth(TollBooth tollBooth);
    }
}