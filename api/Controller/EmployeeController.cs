using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controller.Dtos.Employees;
using api.Data;
using api.Dtos;
using api.IRepositories;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Mvc;


namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly MyDbcontext db;
        private readonly IEmployeeRepo repo;

        public EmployeeController(MyDbcontext db, IEmployeeRepo employeeRepo)
        {
            this.db = db;
            repo = employeeRepo;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var tar = await repo.GetAllEmployees();
            var tar1 = tar.Select(x => x.EmployeeToEmployeeDto());
            return Ok(tar1);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var employee = await repo.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee.EmployeeToEmployeeDto());
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateEmployeeDto employeeDto)
        {
            var emp = employeeDto.EmployDtoToEmployee();
            await repo.Create(emp);
            return CreatedAtAction("GetById", new { id = emp.Id }, emp.EmployeeToEmployeeDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CreateEmployeeDto dto)
        {
            var empmodel = await repo.Update(id, dto);
            if (empmodel == null)
            {
                return NotFound();
            }
            return Ok(empmodel.EmployeeToEmployeeDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var empmodel = await repo.Delete(id);
            if (empmodel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
