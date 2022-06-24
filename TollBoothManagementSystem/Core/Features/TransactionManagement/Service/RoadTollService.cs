using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;
using System.Linq;
using TollBoothManagementSystem.Core.Features.General.Model;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class RoadTollService : IRoadTollService
    {
        private readonly IRoadTollRepository _roadTollRepository;

        public RoadTollService(IRoadTollRepository roadTollRepository)
        {
            _roadTollRepository = roadTollRepository;
        }

        public List<RoadToll> RoadTollsForSection(Section section)
        {
            List<RoadToll> roadTolls = new List<RoadToll>();
            foreach (TollStation tollStation in section.TollStations)
            {
                List<RoadToll> tollsForStation = RoadTollsForTollStation(tollStation);
                roadTolls.Concat(tollsForStation);
            }
            return roadTolls;
            
        }

        public List<RoadToll> RoadTollsForTollStation(TollStation tollStation)
        {
            return _roadTollRepository.ReadAll().Where(r => r.TollStation == tollStation).ToList();
        }

        public RoadToll GetRoadToll(VehicleType vehicleType, Currency currency, TollStation exitStation)
        {
            return _roadTollRepository.ReadAll().First(e => e.VehicleType == vehicleType && e.Currency == currency && e.TollStation == exitStation);
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
