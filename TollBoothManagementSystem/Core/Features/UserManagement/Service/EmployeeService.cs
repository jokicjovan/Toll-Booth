using System;
using System.Collections.Generic;
using System.Linq;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Repository;

namespace TollBoothManagementSystem.Core.Features.UserManagement.Service
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #region CRUD methods

        public IEnumerable<Employee> ReadAll()
        {
            return _employeeRepository.ReadAll();
        }

        public Employee Read(Guid employeeId)
        {
            return _employeeRepository.Read(employeeId);
        }

        public Employee Create(Employee newEmployee)
        {
            return _employeeRepository.Create(newEmployee);
        }

        public Employee Update(Employee employeeToUpdate)
        {
            return _employeeRepository.Update(employeeToUpdate);
        }

        public Employee Delete(Guid employeeToDelete)
        {
            return _employeeRepository.Delete(employeeToDelete);
        }

        #endregion

        public IEnumerable<Employee> getStationEmployees(TollStation tollStation)
        {
            return _employeeRepository.ReadAll().Where(employee => { 
                if (employee.TollStation != null)
                    return employee.TollStation.Id == tollStation.Id;
                else return false;  });
        }

        public IEnumerable<Employee> GetEmployeesBySearchText(string searchText)
        {
            searchText = searchText.ToLower();
            var roles = Enum.GetValues(typeof(Role)).Cast<Role>().Where(text => Enum.GetName(typeof(Role), text).ToLower().Contains(searchText));
            return _employeeRepository.ReadAll().Where(employee => employee.FirstName.ToLower().Contains(searchText)
           || employee.LastName.ToLower().Contains(searchText) || roles.Contains(employee.Role));
        }
    }
}
