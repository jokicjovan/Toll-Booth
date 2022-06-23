using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Repository;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Service
{
    public class TollBoothService : ITollBoothService
    {
        private readonly ITollBoothRepository _tollBoothRepository;

        public TollBoothService(ITollBoothRepository tollBoothRepository)
        {
            _tollBoothRepository = tollBoothRepository;
        }

        #region CRUD
        public TollBooth Create(TollBooth entity)
        {
            return _tollBoothRepository.Create(entity);
        }

        public TollBooth Delete(Guid id)
        {
            return _tollBoothRepository.Delete(id);
        }

        public TollBooth Read(Guid id)
        {
            return _tollBoothRepository.Read(id);
        }

        public IEnumerable<TollBooth> ReadAll()
        {
            return _tollBoothRepository.ReadAll();
        }

        public TollBooth Update(TollBooth entity)
        {
            return _tollBoothRepository.Update(entity);
        }
        #endregion
    }
}
