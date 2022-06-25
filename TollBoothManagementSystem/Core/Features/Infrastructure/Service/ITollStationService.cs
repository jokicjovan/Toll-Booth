using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Service
{
    public interface ITollStationService : ICrudRepository<TollStation>
    {
        public void FireEmployee(TollStation tollStation, Employee employee);
    }
}
