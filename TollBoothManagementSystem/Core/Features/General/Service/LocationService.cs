using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.General.Repository;

namespace TollBoothManagementSystem.Core.Features.General.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        #region CRUD methods

        public IEnumerable<Location> ReadAll()
        {
            return _locationRepository.ReadAll();
        }

        public Location Read(Guid locationId)
        {
            return _locationRepository.Read(locationId);
        }

        public Location Create(Location newLocation)
        {
            return _locationRepository.Create(newLocation);
        }

        public Location Update(Location locationToUpdate)
        {
            return _locationRepository.Update(locationToUpdate);
        }

        public Location Delete(Guid locationId)
        {
            return _locationRepository.Delete(locationId);
        }

        #endregion
    }
}
