using System;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public interface ISectionService : ICrudRepository<Section>
    {
        public Section GetSection(TollStation tollStation);

        public bool IsOrderNumberValid(int orderNumber, Guid sectionId);

        public void ShiftTollStationOrderNumbers(int orderNumber, Guid sectionId);
    }
}
