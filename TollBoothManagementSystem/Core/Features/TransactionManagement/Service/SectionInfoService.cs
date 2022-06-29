using System;
using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class SectionInfoService : ISectionInfoService
    {
        private readonly ISectionInfoRepository _sectionInfoRepository;

        public SectionInfoService(ISectionInfoRepository sectionInfoRepository)
        {
            _sectionInfoRepository = sectionInfoRepository;
        }

        public SectionInfo Create(SectionInfo entity)
        {
            return _sectionInfoRepository.Create(entity);
        }

        public SectionInfo Delete(Guid id)
        {
            return _sectionInfoRepository.Delete(id);
        }

        public SectionInfo Read(Guid id)
        {
            return _sectionInfoRepository.Read(id);
        }

        public IEnumerable<SectionInfo> ReadAll()
        {
            return _sectionInfoRepository.ReadAll();
        }

        public SectionInfo Update(SectionInfo entity)
        {
            return _sectionInfoRepository.Update(entity);
        }

        public double CalculateDistance(TollStation enterStation, TollStation exitStation)
        {
            double distance1 = _sectionInfoRepository.ReadAll().First(e => e.TollStation.Id == enterStation.Id).Distance;
            double distance2 = _sectionInfoRepository.ReadAll().First(e => e.TollStation.Id == exitStation.Id).Distance;
            return Math.Abs(distance2 - distance1);
        }

        public SectionInfo getSectionInfoForTollStation(Guid tollStationId)
        {
            return _sectionInfoRepository.ReadAll()
                                         .First(si =>
                                         {
                                             return si.TollStation.Id == tollStationId;
                                         });
        }
    }
}
