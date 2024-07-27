using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controller.Dtos.Employees;
using api.Dtos;
using api.Dtos.Departments;
using api.Model;
namespace api.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeesDto? EmployeeToEmployeeDto(this Employee employee)
        {
            if (employee.department == null)
            {
                return null;
            }
            return new EmployeesDto
            {
                Name = employee.Name,
                email = employee.email,
                CreatedDate = employee.CreatedDate,
                Department = employee.department.DepartmentToDepartmentDto(),
            };
        }
        public static Employee EmployDtoToEmployee(this CreateEmployeeDto employee)
        {
            return new Employee
            {
                Name = employee.Name,
                email = employee.email,
                CreatedDate = employee.CreatedDate,
                Password = employee.Password,
                DepartmentId = employee.departmentId,

            };
        }

        public static Department DepartmenDtoToDepartmet(this CreateDepartmentDto dep)
        {
            return new Department
            {
                Name = dep.Name,

            };
        }
        public static DepartmentDto DepartmentToDepartmentDto(this Department dep)
        {
            if (dep == null)
            {
                return new DepartmentDto();
            }
            return new DepartmentDto
            {
                Id = dep.Id,
                Name = dep.Name,
            };
        }

    }
}//ANCHOR - dotnet new webapi -o api , dotnet ef migrations add init , dotnet ef database update, dotnet watch run