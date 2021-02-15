using RedArbor.Domain.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Infrastructure.Repository.Interfaces.Interfaces
{
    public interface IEmployeeRepository
    {
        EmployeeEntity[] GetAllEmployees();
        EmployeeEntity GetEmployeeById(int id);
        EmployeeEntity AddEmployee(EmployeeEntity employee);
        bool UpdateEmployeeUsernameById(int id, string username);
        bool DeleteEmployeeById(int id);
    }
}
