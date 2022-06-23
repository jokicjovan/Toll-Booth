using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Service
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

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
    }
}
