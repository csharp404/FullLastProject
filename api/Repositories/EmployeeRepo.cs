using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.IRepositories;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private MyDbcontext db;

        public EmployeeRepo(MyDbcontext my)
        {
            this.db = my;
        }

        public async Task<Employee?> Update(int id, CreateEmployeeDto employee)
        {
            var target = await db.Employees.Include(x => x.department).FirstOrDefaultAsync(x => x.Id == id);
            if (target == null)
            {
                return null;
            }
            target.email = employee.email;
            target.Name = employee.Name;
            target.CreatedDate = employee.CreatedDate;
            target.Password = employee.Password;
            target.DepartmentId = employee.departmentId;
            await db.SaveChangesAsync();
            return employee.EmployDtoToEmployee();
        }
        public async Task<Employee> Create(Employee employee)
        {
            await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> Delete(int id)
        {
            var target = db.Employees.FirstOrDefault(x => x.Id == id);
            if (target == null)
            {
                return null;
            }
            db.Employees.Remove(target);
            await db.SaveChangesAsync();
            return target;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await db.Employees.Include(x => x.department).ToListAsync();
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            var target = await db.Employees.Include(x => x.department).FirstOrDefaultAsync(x => x.Id == id);
            if (target == null)
                return null;

            return target;


        }

    }
}