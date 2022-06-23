using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class RoadTollService : IRoadTollService
    {
        private readonly IRoadTollRepository _roadTollRepository;

        public RoadTollService(IRoadTollRepository roadTollRepository)
        {
            _roadTollRepository = roadTollRepository;
        }

        #region CRUD methods

        public IEnumerable<RoadToll> ReadAll()
        {
            return _roadTollRepository.ReadAll();
        }

        public RoadToll Read(Guid roadTollId)
        {
            return _roadTollRepository.Read(roadTollId);
        }

        public RoadToll Create(RoadToll newRoadToll)
        {
            return _roadTollRepository.Create(newRoadToll);
        }

        public RoadToll Update(RoadToll roadTollToUpdate)
        {
            return _roadTollRepository.Update(roadTollToUpdate);
        }

        public RoadToll Delete(Guid roadTollId)
        {
            return _roadTollRepository.Delete(roadTollId);
        }

        #endregion
    }
}
