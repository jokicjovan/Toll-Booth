﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Repository
{
    public class TollBoothRepository : CrudRepository<TollBooth>, ITollBoothRepository
    {
        public TollBoothRepository(DatabaseContext context) : base(context)
        {

        }

        public override TollBooth Delete(Guid id)
        {
            var entityToDelete = Read(id);
            if (entityToDelete != null)
            {
                entityToDelete.IsActive = false;
                entityToDelete.TollStation = null;
                Update(entityToDelete);
            }

            return entityToDelete;
        }
    }
}
