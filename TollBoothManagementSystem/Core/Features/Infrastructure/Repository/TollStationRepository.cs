using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Repository
{
    public class TollStationRepository : CrudRepository<TollStation>, ITollStationRepository
    {
        public TollStationRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
