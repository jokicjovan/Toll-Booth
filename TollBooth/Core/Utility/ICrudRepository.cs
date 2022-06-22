using System;
using System.Collections.Generic;
using TollBooth.Core.Utility.HelperClasses;

namespace TollBooth.Core.Utility
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
