using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CreateEmployeeDto
    {
        public string? Name { get; set; }
        public string? email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Password { get; set; }
        public int departmentId { get; set; }
    }
}