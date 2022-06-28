using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Repository;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Service
{
    public class TollStationService : ITollStationService
    {
        private readonly ITollStationRepository _tollStationRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IRoadTollPaymentService _roadTollPaymentService;
        public TollStationService(ITollStationRepository tollStationRepository, IEmployeeService employeeService, IRoadTollPaymentService roadTollPaymentService)
        {
            _employeeService = employeeService;
            _tollStationRepository = tollStationRepository;
            _roadTollPaymentService = roadTollPaymentService;
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
            _employeeService.Delete(employee.Id);
        }

        public void FireAllEmployees(TollStation tollStation) 
        {
            while (tollStation.Employees.Count > 0) {
                _employeeService.Delete(tollStation.Employees[0].Id);
            }

            tollStation.Boss = null;
            tollStation.Employees.Clear();
            Update(tollStation);
        }

        public double GetIncome(TollStation tollStation, DateTime startDate, DateTime endDate, Currency currency)
        {
            IEnumerable<Payment> payments = _roadTollPaymentService.GetPaymentsForStation(tollStation)
                .Where(e => e.ExitTime.Date >= startDate.Date)
                .Where(e => e.ExitTime.Date <= endDate.Date)
                .Where(e => e.Currency.Id == currency.Id);
            return payments.Sum(e => e.Price);
        }
    }
}
