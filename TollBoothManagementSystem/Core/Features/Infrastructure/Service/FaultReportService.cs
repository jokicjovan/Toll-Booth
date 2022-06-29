using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Repository;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Service
{
    public class FaultReportService : IFaultReportService
    {
        private readonly IFaultReportRepository _faultReportRepository;

        public FaultReportService(IFaultReportRepository faultReportRepository)
        {
            _faultReportRepository = faultReportRepository;
        }

        #region CRUD
        public FaultReport Create(FaultReport entity)
        {
            return _faultReportRepository.Create(entity);
        }

        public FaultReport Delete(Guid id)
        {
            return _faultReportRepository.Delete(id);
        }

        public FaultReport Read(Guid id)
        {
            return _faultReportRepository.Read(id);
        }

        public IEnumerable<FaultReport> ReadAll()
        {
            return _faultReportRepository.ReadAll();
        }

        public FaultReport Update(FaultReport entity)
        {
            return _faultReportRepository.Update(entity);
        }

        #endregion
    }
}
