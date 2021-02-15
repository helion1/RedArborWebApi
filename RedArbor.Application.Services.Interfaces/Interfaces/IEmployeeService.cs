using RedArbor.Application.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto[] GetAllEmployees();
        EmployeeDto GetEmployeeById(int id);
        EmployeeDto AddEmployee(EmployeeDto employee);
        bool UpdateEmployeeUsernameById(int id, string username);
        bool DeleteEmployeeById(int id);
    }
}
