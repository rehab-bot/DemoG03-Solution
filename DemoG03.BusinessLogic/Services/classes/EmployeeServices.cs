using DemoG03.BusinessLogic.DTOs.Employees;
using DemoG03.BusinessLogic.Services.interfaces;
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

        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees(bool WithTracking = false)
        {
            var employee = _employeeRepository.GetAll(WithTracking);
            var employeeToReturn = employee.Select(E => new EmployeeDTO()
            {
                Id = E.Id,
                Name = E.Name,
                Age = E.Age,
                Email = E.Email,
                IsActive = E.IsActive,
                Salary = E.Salary,
                Gender = E.Gender,
                EmployeeType = E.EmployeeType

            });
            return employeeToReturn;
        }
        public EmployeeDetailsDTO? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                return null;
            }
            return new EmployeeDetailsDTO()
            {

                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Gender = employee.Gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString(),
                CreatedBy = employee.CreatedBy,
                CreatedOn = employee.CreatedOn,
                LastModifiedBy = employee.LastModifiedBy,
                LastModifiedOn = employee.LastModifiedOn,
            };
        }

        public int CreateEmployee(CreatedEmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }



    }
    }

