using DemoG03.BusinessLogic.DTOs;
using DemoG03.BusinessLogic.Factories;
using DemoG03.DataAccess.Models;
using DemoG03.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        public readonly IDepartmentRepository _departmentRepository;
        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            var departmentsToReturn = departments.Select(D => D.ToDepartmentDTo());
            return departmentsToReturn;
        }
        public DepartmentDetailsDTO? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            return department == null ? null : department.ToDepartmentDetailsDTO();


        }



        public int AddDepartment(CreatedDepartmentDTO departmentDto)
        {
            return _departmentRepository.Add(departmentDto.ToEntity());

        }
        public int UpdateDepartment(UpdatedDepartmentDTO departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());

        }
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null)
                return false;
            else
            {
                var result = _departmentRepository.Delete(department);
                return result > 0 ? true : false;
            }
        }


    }

}
