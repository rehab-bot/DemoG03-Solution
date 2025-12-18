using AutoMapper;
using DemoG03.BusinessLogic.DTOs.Employees;
using DemoG03.DataAccess.Models.Employees;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dist => dist.EmpGender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmpEmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.DepartmentName, options => options.MapFrom(src => src.Department == null ? "No Department":src.Department.Name ));
            CreateMap<Employee, EmployeeDetailsDTO>()
                .ForMember(dist => dist.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));

            CreateMap<CreatedEmployeeDTO, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())));
          

            CreateMap<UpdatedEmployeeDTO, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())));

       

        }
    }
}
