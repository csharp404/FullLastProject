using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Departments;
using api.Model;

namespace api.Controller.Dtos.Employees
{
    public class EmployeesDto
    {

        public string? Name { get; set; }
        public string? email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DepartmentDto? Department { get; set; }

    }
}