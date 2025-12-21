using AutoMapper;
using DemoG03.BusinessLogic.DTOs.Employees;
using DemoG03.BusinessLogic.Services.interfaces;
using DemoG03.DataAccess.Models.Employees;
using DemoG03.DataAccess.Repositories.Departments;
using DemoG03.DataAccess.Repositories.Employees;
using DemoG03.DataAccess.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.Services.classes
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAttachmentServices _attachmentServices;
        public EmployeeServices(IUnitOfWork unitOfWork,
            IMapper mapper,
           IAttachmentServices attachmentServices )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _attachmentServices =attachmentServices;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees(bool WithTracking = false)
        { //var employees =_employeeRepository.GetEnumerable();
            // var emploueesToReturn = employees.Select(E => new EmployeeDTO()  
            var employee = _unitOfWork.EmployeeRepository.GetAll(WithTracking);
            var employeeToReturn = _mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDTO>>(employee);
            //var employees = _employeeRepository.GetAll(E => new EmployeeDTO()
            //{
            //    Id= E.Id,
            //    Name = E.Name,
            //    Age = E.Age,
            //   Salary = E.Salary,
              
            //}).Where(E => E.Age > 30);

            return employeeToReturn;
        }
            #region 
            ////var employeeToReturn = employee.Select(E => new EmployeeDTO()
            ////{
            ////    Id = E.Id,
            ////    Name = E.Name,
            ////    Age = E.Age,
            ////    Email = E.Email,
            ////    IsActive = E.IsActive,
            ////    Salary = E.Salary,
            ////    Gender = E.Gender,
            ////    EmployeeType = E.EmployeeType

            ////});
            #endregion 
       
     
        public EmployeeDetailsDTO? GetEmployeeById(int id)
        {    var employee = _unitOfWork.EmployeeRepository.GetById(id);
            return employee is null ? null:_mapper.Map<Employee,EmployeeDetailsDTO>(employee);
            {

                //Id = employee.Id,
                //Name = employee.Name,
                //Age = employee.Age,
                //Email = employee.Email,
                //HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                //IsActive = employee.IsActive,
                //Salary = employee.Salary,
                //Gender = employee.Gender.ToString(),
                //EmployeeType = employee.EmployeeType.ToString(),
                //CreatedBy = employee.CreatedBy,
                //CreatedOn = employee.CreatedOn,
                //LastModifiedBy = employee.LastModifiedBy,
                //LastModifiedOn = employee.LastModifiedOn,
            };
        }

        public int CreateEmployee(CreatedEmployeeDTO employeeDTO)
        {
           var employee =_mapper.Map<CreatedEmployeeDTO, Employee>(employeeDTO);
            if (employeeDTO.Image is not null)

              employee.ImageName =  _attachmentServices.Upload(employeeDTO.Image, "Images");
                
            _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.SaveChanges();
        } 
        public int UpdateEmployee(int id, UpdatedEmployeeDTO employeeDTO)
        {
          _unitOfWork.EmployeeRepository.Update(_mapper.Map<UpdatedEmployeeDTO, Employee>(employeeDTO));

            return _unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
           var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee is null)
                return false;
            employee.IsDeleted = true;
         _unitOfWork.EmployeeRepository.Update(employee);
            var result =  _unitOfWork.SaveChanges();

            if (result>0)
                return true;
            return false;
        


        }

        public int UpdateEmployee(UpdatedEmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }
    }
    }

