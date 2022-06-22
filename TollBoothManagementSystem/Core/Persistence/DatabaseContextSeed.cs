using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollBoothManagementSystem.Core.Persistence
{
    public class DatabaseContextSeed
    {
        public static void Seed(DatabaseContext context)
        {
            context.SaveChanges();
        }
    }
}
