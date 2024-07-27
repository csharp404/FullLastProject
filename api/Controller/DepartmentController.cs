using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Departments;
using api.IRepositories;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepo repo;

        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            this.repo = departmentRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var target = await repo.GetAllDepartment();
            var target1 = target.Select(x => x.DepartmentToDepartmentDto());
            return Ok(target1);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetDepartmentById([FromRoute] int id)
        {
            var target = await repo.GetDepartment(id);
            if (target == null)
            {
                return NotFound();
            }
            return Ok(target.DepartmentToDepartmentDto());
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateDepartmentDto department)
        {
            var dep = department.DepartmenDtoToDepartmet();
            var tsk = await repo.CreateDepartment(dep);
            if (tsk == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetDepartmentById",new{id = dep.Id}, dep.DepartmentToDepartmentDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CreateDepartmentDto department)
        {
            var tsk = await repo.UpdateDepartment(id, department);
            if (tsk == null)
            {
                return NotFound();
            }
            return Ok();




        }



    }
}