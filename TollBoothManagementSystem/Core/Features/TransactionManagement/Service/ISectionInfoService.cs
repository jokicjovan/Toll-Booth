using System;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public interface ISectionInfoService : ICrudRepository<SectionInfo>
    {
        double CalculateDistance(TollStation enterStation, TollStation exitStation);

        public SectionInfo getSectionInfoForTollStation(Guid tollStationId);
    }
}
