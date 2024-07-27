using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {

        private readonly IMapper mpr;
        private readonly Uri uri;
        private readonly HttpClient httpClient = new HttpClient();

        public DepartmentController(ILogger<DepartmentController> logger, IMapper mapper)
        {
            uri = new Uri("http://localhost:5032/api/");

            httpClient.BaseAddress = uri;
            this.mpr = mapper;
        }

        public async Task<IActionResult?> Index()
        {
            var res = await httpClient.GetAsync("Department");
            if (res.IsSuccessStatusCode)
            {
                string dataAsSting = await res.Content.ReadAsStringAsync();
                var js = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var data = JsonSerializer.Deserialize<List<DepartmentViewModel>>(dataAsSting, js);
                return View(data);
            }
            return null;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(DepartmentViewModelCreate model)
        {

            var res = await httpClient.PostAsJsonAsync("Department", model);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Department");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var res = await httpClient.GetAsync("Department/" + id);
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                var js = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var model = JsonSerializer.Deserialize<DepartmentViewModelCreate>(content,js);
                return View("Create",model); 
            }
            return View("Create", null);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, DepartmentViewModelCreate model)
        {
            var res =await  httpClient.PutAsJsonAsync("Department/" + id, model);
            if (res.IsSuccessStatusCode) {
                return RedirectToAction("Index", "Department");
            }
            return View(model);
        }

    }
}