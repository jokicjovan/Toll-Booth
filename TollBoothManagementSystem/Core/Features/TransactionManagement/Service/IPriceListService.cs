using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public interface IPriceListService : ICrudRepository<PriceList>
    {
        public PriceList GetActivePricelist(Section section);
    }
}