using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Departments;
using api.Model;

namespace api.IRepositories
{
    public interface IDepartmentRepo
    {
        Task<List<Department>> GetAllDepartment();
        Task<Department?> GetDepartment(int id);
        Task<Department> CreateDepartment(Department department);

        Task<Department?> UpdateDepartment(int id, CreateDepartmentDto department);



    }
}