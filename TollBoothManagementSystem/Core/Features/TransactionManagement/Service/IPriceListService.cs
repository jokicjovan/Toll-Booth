using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public interface IPriceListService : ICrudRepository<PriceList>
    {
        PriceList GetActivePricelist(Section section);
        public PriceList CurrentPriceListForSection(Section sec);
    }
}