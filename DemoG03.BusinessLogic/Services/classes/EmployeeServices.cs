using AutoMapper;
using DemoG03.BusinessLogic.DTOs.Employees;
using DemoG03.BusinessLogic.Services.interfaces;
using DemoG03.DataAccess.Models.Employees;
using DemoG03.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.Services.classes
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeServices(IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees(bool WithTracking = false)
        { //var employees =_employeeRepository.GetEnumerable();
            // var emploueesToReturn = employees.Select(E => new EmployeeDTO()  
            var employee = _employeeRepository.GetAll(WithTracking);
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
        {    var employee = _employeeRepository.GetById(id);
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
            return _employeeRepository.Add(employee);
        }
        public int UpdateEmployee(int id, UpdatedEmployeeDTO employeeDTO)
        {
           return _employeeRepository.Update( _mapper.Map<UpdatedEmployeeDTO, Employee>(employeeDTO));

        }

        public bool DeleteEmployee(int id)
        {
           var employee = _employeeRepository.GetById(id);
            if (employee is null)
                return false;
            employee.IsDeleted = true;
           var result = _employeeRepository.Update(employee);
          
              return result > 0 ? true : false;
            
        }

        public int UpdateEmployee(UpdatedEmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }
    }
    }

