using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class RoadTollPriceService : IRoadTollPriceService
    {
        private readonly IRoadTollPriceRepository _roadTollPriceRepository;

        public RoadTollPriceService(IRoadTollPriceRepository roadTollPriceRepository)
        {
            _roadTollPriceRepository = roadTollPriceRepository;
        }

        #region CRUD methods

        public IEnumerable<RoadTollPrice> ReadAll()
        {
            return _roadTollPriceRepository.ReadAll();
        }

        public RoadTollPrice Read(Guid roadTollPriceId)
        {
            return _roadTollPriceRepository.Read(roadTollPriceId);
        }

        public RoadTollPrice Create(RoadTollPrice newRoadTollPrice)
        {
            return _roadTollPriceRepository.Create(newRoadTollPrice);
        }

        public RoadTollPrice Update(RoadTollPrice roadTollPriceToUpdate)
        {
            return _roadTollPriceRepository.Update(roadTollPriceToUpdate);
        }

        public RoadTollPrice Delete(Guid roadTollPriceId)
        {
            return _roadTollPriceRepository.Delete(roadTollPriceId);
        }

        #endregion
    }
}
