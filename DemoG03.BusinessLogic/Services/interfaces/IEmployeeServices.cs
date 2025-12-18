using DemoG03.BusinessLogic.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.Services.interfaces
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeDTO> GetAllEmployees(bool WithTracking = false);
        EmployeeDetailsDTO? GetEmployeeById(int id);
        int CreateEmployee(CreatedEmployeeDTO employeeDTO);
      
        bool DeleteEmployee(int id);
       int UpdateEmployee(UpdatedEmployeeDTO employeeDTO);
    }
}
