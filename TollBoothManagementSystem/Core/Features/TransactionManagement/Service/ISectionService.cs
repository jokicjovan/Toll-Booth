using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public interface ISectionService : ICrudRepository<Section>
    {
        Section GetSection(TollStation tollStation);
    }
}
