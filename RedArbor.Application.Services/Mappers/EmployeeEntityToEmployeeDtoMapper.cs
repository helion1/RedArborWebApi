using RedArbor.Application.Services.DtoModels;
using RedArbor.Domain.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Application.Services.Mappers
{
    public static class EmployeeEntityToEmployeeDtoMapper
    {
        public static EmployeeDto Convert(EmployeeEntity employeeEntity)
        {
            return new EmployeeDto(employeeEntity.CompanyId,
                                    employeeEntity.CreatedOn,
                                    employeeEntity.DeletedOn,
                                    employeeEntity.Email,
                                    employeeEntity.Fax,
                                    employeeEntity.Name,
                                    employeeEntity.LastLogin,
                                    employeeEntity.Password,
                                    employeeEntity.PortalId,
                                    employeeEntity.RoleId,
                                    employeeEntity.StatusId,
                                    employeeEntity.Telephone,
                                    employeeEntity.UpdatedOn,
                                    employeeEntity.Username
                                    ) ?? null;
        }

        public static EmployeeDto[] ConvertArray(EmployeeEntity[] employeesEntity)
        {
            var employeesDto = new EmployeeDto[employeesEntity.Length];
            var count = 0;

            foreach (var employee in employeesEntity)
            {
                employeesDto[count] = Convert(employee);
                count++;
            }

            return employeesDto;
        }

    }
}
