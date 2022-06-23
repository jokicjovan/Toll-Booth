using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.General.Repository
{
    public class CurrencyRepository : CrudRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
