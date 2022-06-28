using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public interface IRoadTollPriceService : ICrudRepository<RoadTollPrice>
    {
        double CalculatePrice(PriceList pricelist, VehicleType vehicleType, Currency currency, TollStation enterStation, TollStation exitStation);

        public void GeneratePrices(PriceList priceList, TollStation tollStation, int basePrice);
    }
}