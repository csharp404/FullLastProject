using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<DepartmentModel, DepartmentViewModel>().ReverseMap();
            CreateMap<DepartmentModel, DepartmentViewModelCreate>().ReverseMap();
            CreateMap<EmployeeModel, EmployeeViewModel>().ReverseMap();
            CreateMap<EmployeeModel, EmployeeViewModelCreate>().ReverseMap();
            CreateMap<CreateUser, AppUser>().ReverseMap();

        }
    }
}