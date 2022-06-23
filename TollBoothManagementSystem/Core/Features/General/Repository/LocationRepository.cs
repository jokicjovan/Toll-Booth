using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.General.Repository
{
    public class LocationRepository : CrudRepository<Currency>, ILocationRepository
    {
        public LocationRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
