using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public interface IRoadTollService : ICrudRepository<RoadToll>
    {
        RoadToll GetRoadToll(VehicleType vehicleType, Currency currency, TollStation exitStation);
        public List<RoadToll> RoadTollsForSection(Section section);

        public List<RoadToll> RoadTollsForTollStation(TollStation tollStation);
    }
}