using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedArbor.Application.Services.DtoModels;
using RedArbor.Application.Services.Interfaces;
using RedArbor.Application.Services.Mappers;
using RedArbor.Domain.Entities.EntityModels;
using RedArbor.Infrastructure.Repository.Interfaces.Interfaces;
using RedArbor.Infrastructure.Repository.Repository;

namespace RedArbor.Application.Services.Service
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public EmployeeDto[] GetAllEmployees()
        {
            var allEmployees = _employeeRepository.GetAllEmployees();
            return (allEmployees != null) ? EmployeeEntityToEmployeeDtoMapper.ConvertArray(allEmployees) : null;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return (employee != null) ? EmployeeEntityToEmployeeDtoMapper.Convert(employee) : null;
        }

        public EmployeeDto AddEmployee(EmployeeDto employee)
        {
            var employeeEntityAdded = _employeeRepository.AddEmployee(EmployeeDtoToEmployeeEntityMapper.Convert(employee));
            return EmployeeEntityToEmployeeDtoMapper.Convert(employeeEntityAdded);
        }

        public bool UpdateEmployeeUsernameById(int id, string username)
        {
            return _employeeRepository.UpdateEmployeeUsernameById(id, username);
        }

        public bool DeleteEmployeeById(int id)
        {
            return _employeeRepository.DeleteEmployeeById(id);
        }

    }
}
