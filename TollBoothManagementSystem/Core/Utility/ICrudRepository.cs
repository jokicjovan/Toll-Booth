﻿using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.Core.Utility
{
    public interface ICrudRepository<T> where T : IBaseEntity
    {
        IEnumerable<T> ReadAll();

        T Read(Guid id);

        T Create(T entity);

        T Update(T entity);

        T Delete(Guid id);
    }
}
