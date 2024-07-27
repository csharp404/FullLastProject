using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Departments;
using api.IRepositories;
using api.Mappers;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly MyDbcontext db;

        public DepartmentRepo(MyDbcontext db)
        {
            this.db = db;
        }
        public async Task<List<Department>> GetAllDepartment()
        {
            return await db.Departments.Include(x => x.Employees).ToListAsync();

        }
        public async Task<Department> CreateDepartment(Department department)
        {
            await db.AddAsync(department);
            await db.SaveChangesAsync();
            return department;
        }




        public async Task<Department?> GetDepartment(int id)
        {
            var tar = await db.Departments.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
            if (tar == null)
            {
                return null;
            }
            return tar;
        }

        public async Task<Department?> UpdateDepartment(int id, CreateDepartmentDto department)
        {
            var tar = await db.Departments.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
            if (tar == null)
            {
                return null;
            }
            tar.Name = department.Name;
            await db.SaveChangesAsync();
            return (department.DepartmenDtoToDepartmet());
        }
    }
}