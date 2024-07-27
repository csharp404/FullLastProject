using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {

        private readonly IMapper mpr;

        public EmployeeController(ILogger<DepartmentController> logger, IMapper mapper)
        {

            this.mpr = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}