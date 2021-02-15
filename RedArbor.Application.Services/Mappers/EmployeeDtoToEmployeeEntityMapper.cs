using RedArbor.Application.Services.DtoModels;
using RedArbor.Domain.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Application.Services.Mappers
{
    public static class EmployeeDtoToEmployeeEntityMapper
    {
        public static EmployeeEntity Convert(EmployeeDto employeeDto)
        {
            return new EmployeeEntity
            {
                CompanyId = employeeDto.CompanyId,
                CreatedOn = employeeDto.CreatedOn,
                DeletedOn = employeeDto.DeletedOn,
                Email = employeeDto.Email,
                Fax = employeeDto.Fax,
                Name = employeeDto.Name,
                LastLogin = employeeDto.LastLogin,
                Password = employeeDto.Password,
                PortalId = employeeDto.PortalId,
                RoleId = employeeDto.RoleId,
                StatusId = employeeDto.StatusId,
                Telephone = employeeDto.Telephone,
                UpdatedOn = employeeDto.UpdatedOn,
                Username = employeeDto.Username
            };
        }
    }
}
