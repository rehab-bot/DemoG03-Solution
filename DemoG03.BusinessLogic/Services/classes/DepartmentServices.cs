using DemoG03.BusinessLogic.DTOs.Departments;
using DemoG03.BusinessLogic.Factories;
using DemoG03.BusinessLogic.Services.interfaces;
using DemoG03.DataAccess.Models;
using DemoG03.DataAccess.Repositories.Departments;
using DemoG03.DataAccess.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.Services.classes
{ 
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentServices(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentsToReturn = departments.Select(D => D.ToDepartmentDTo());
            return departmentsToReturn;
        }
        public DepartmentDetailsDTO? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);

            return department == null ? null : department.ToDepartmentDetailsDTO();


        }



        public int AddDepartment(CreatedDepartmentDTO departmentDto)
        { _unitOfWork.DepartmentRepository.Add(departmentDto.ToEntity());
        
            return _unitOfWork.SaveChanges();
        }
        public int UpdateDepartment(UpdatedDepartmentDTO departmentDto)
        {
           _unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
            return _unitOfWork.SaveChanges();

        }
        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null)
                return false;
            else
            {
                _unitOfWork.DepartmentRepository.Delete(department);
                var result =_unitOfWork.SaveChanges();
                return result > 0 ? true : false;
            }
        }

       

      
    }

}
