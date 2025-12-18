using DemoG03.BusinessLogic.DTOs.Departments;
using DemoG03.DataAccess.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic
{
    internal static class DepartmentFactroy
    { public static DepartmentDetailsDTO ToDepartmentDetailsDTO(this Department department)
        {
            return new DepartmentDetailsDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now),
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,
                IsDeleted = department.IsDeleted,
            };

        }
        public static DepartmentDTO ToDepartmentDTo(this Department department)
        { return new DepartmentDTO()
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            DateOfCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now)

        };
        }
        public static Department ToEntity(this CreatedDepartmentDTO departmentDTO)
        {
            return new Department()
            {
                Code = departmentDTO.Code,
                Name = departmentDTO.Name,
                Description = departmentDTO.Description,
                CreatedOn = departmentDTO.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
        public static Department ToEntity(this UpdatedDepartmentDTO departmentDTO)
        {
            return new Department()
            {
                Id = departmentDTO.Id,
                Code = departmentDTO.Code,
                Name = departmentDTO.Name,
                Description = departmentDTO.Description,
                CreatedOn = departmentDTO.DateOfCreation.ToDateTime(new TimeOnly())
            };
    
        } 
    }

}
