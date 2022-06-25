using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Repository;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Service
{
    public class TollStationService : ITollStationService
    {
        private readonly ITollStationRepository _tollStationRepository;

        public TollStationService(ITollStationRepository tollStationRepository)
        {
            _tollStationRepository = tollStationRepository;
        }

        public TollStation Create(TollStation entity)
        {
            return _tollStationRepository.Create(entity);
        }

        public TollStation Delete(Guid id)
        {
            return _tollStationRepository.Delete(id);
        }

        public TollStation Read(Guid id)
        {
            return _tollStationRepository.Read(id);
        }

        public IEnumerable<TollStation> ReadAll()
        {
            return _tollStationRepository.ReadAll();
        }

        public TollStation Update(TollStation entity)
        {
            return _tollStationRepository.Update(entity);
        }
        public void FireEmployee(TollStation tollStation, Employee employee)
        {
            if (tollStation.Boss != null && tollStation.Boss.Id == employee.Id) {
                tollStation.Boss = null;
            }

            tollStation.Employees.Remove(employee);
            Update(tollStation);
        }
    }
}
