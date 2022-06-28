using System;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Service
{
    public interface ITollStationService : ICrudRepository<TollStation>
    {
        public void FireEmployee(TollStation tollStation, Employee employee);
        public void FireAllEmployees(TollStation tollStation);
        double GetIncome(TollStation tollStation, DateTime startDate, DateTime endDate, Currency currency);
    }
}
