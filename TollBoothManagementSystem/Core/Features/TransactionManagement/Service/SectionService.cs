using System;
using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        private readonly ITollStationService _tollStationService;

        public SectionService(ISectionRepository sectionRepository, ITollStationService tollStationService)
        {
            _sectionRepository = sectionRepository;
            _tollStationService = tollStationService;
        }

        #region CRUD methods

        public Section Create(Section entity)
        {
            return _sectionRepository.Create(entity);
        }

        public Section Delete(Guid id)
        {
            return _sectionRepository.Delete(id);
        }

        public Section Read(Guid id)
        {
            return _sectionRepository.Read(id);
        }

        public IEnumerable<Section> ReadAll()
        {
            return _sectionRepository.ReadAll();
        }

        public Section Update(Section entity)
        {
            return _sectionRepository.Update(entity);
        }

        public Section GetSection(TollStation tollStation)
        {
            return _sectionRepository.ReadAll().First(e => e.TollStations.Contains(tollStation));
        }

        #endregion

        public bool IsOrderNumberValid(int orderNumber, Guid sectionId)
        {
            if (orderNumber <= 1)
                return false;

            var section = Read(sectionId);

            return section.TollStations.Count >= orderNumber;
        }

        public void ShiftTollStationOrderNumbers(int orderNumber, Guid sectionId)
        {
            var section = Read(sectionId);

            foreach (var tollStation in section.TollStations)
            {
                if (tollStation.OrderNumber >= orderNumber)
                    tollStation.OrderNumber ++;

                _tollStationService.Update(tollStation);
            }
        }

        public void ShiftTollStationOrderNumbersLeft(int orderNumber, Guid sectionId)
        {
            var section = Read(sectionId);

            foreach (var tollStation in section.TollStations)
            {
                if (tollStation.OrderNumber > orderNumber)
                    tollStation.OrderNumber--;

                _tollStationService.Update(tollStation);
            }
        }
        public Section getSectionForTollStation(Guid tollStationId)
        {
            return _sectionRepository.ReadAll()
                                     .First(s =>
                                     {
                                         return s.Origin.Id == tollStationId || s.Destination.Id == tollStationId || s.TollStations.Any(ts => ts.Id == tollStationId);
                                     });
        }
    }
}
