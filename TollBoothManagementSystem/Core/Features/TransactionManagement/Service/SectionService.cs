using System;
using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;
using System.Linq;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        //public Section SectionOfTollStation(TollStation tollStation)
        //{
        //    List<Section> allSec = _sectionRepository.ReadAll().ToList();
        //    foreach (Section sec in allSec)
        //    {
        //        foreach (TollStation ts in sec.TollStations)
        //        {
        //            if (ts == tollStation)
        //            {
        //                return sec;
        //            }
        //        }
        //    }
        //    return null;
        //}

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
    }
}
