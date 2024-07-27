using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class EmployeeViewModel
    {
        public string? Name { get; set; }
        public string? email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DepartmentModel? Department { get; set; }
    }
}