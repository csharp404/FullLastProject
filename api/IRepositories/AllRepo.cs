using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.IRepositories
{
    public interface AllRepo<T> where T : class
    {
        
        public IDepartmentRepo departmentRepo{ get; set; }
        public IEmployeeRepo employeeRepo{ get; set; }
    }
}