using DemoG03.DataAccess.Data.Contexts;
using DemoG03.DataAccess.Models.Departments;
using DemoG03.DataAccess.Models.Employees;
using DemoG03.DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.DataAccess.Repositories.Employees
{
    public class EmployeeRepository :GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDBContext _DbContext;
        
             public EmployeeRepository(ApplicationDBContext DBContext):base(DBContext) 
        {
            _DbContext = DBContext;
        }
       
      
    }

}

 