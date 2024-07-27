using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Employee
    {
        
        public int Id { get; set;}
        public string? Name { get; set; }
        public string? email { get; set; }
        public DateTime CreatedDate { get; set;} = DateTime.Now;
        public string? Password { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public  virtual Department? department { get; set; }

    }
}