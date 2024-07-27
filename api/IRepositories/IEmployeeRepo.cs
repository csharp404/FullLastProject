using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controller.Dtos.Employees;
using api.Dtos;
using api.Model;

namespace api.IRepositories
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployee(int id);
        Task<Employee> Create(Employee employee);
        Task<Employee?> Update(int id, CreateEmployeeDto employee);
        Task<Employee?> Delete(int id);
    }
}