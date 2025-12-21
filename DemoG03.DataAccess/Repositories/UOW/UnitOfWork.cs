
using DemoG03.DataAccess.Data.Contexts;
using DemoG03.DataAccess.Models.Departments;
using DemoG03.DataAccess.Repositories.Departments;
using DemoG03.DataAccess.Repositories.Employees;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.DataAccess.Repositories.UOW
{ 
    public class UnitOfWork : IUnitOfWork
    {
         private Lazy<IDepartmentRepository> _departmentRepository;
        private  Lazy<IEmployeeRepository> _employeeRepository;
        private readonly ApplicationDBContext _DbContext;
        public UnitOfWork(ApplicationDBContext DbContext)
        { 
            _DbContext = DbContext;
            _departmentRepository = new Lazy<IDepartmentRepository>(()=> new DepartmentRepository(_DbContext));
            _employeeRepository = new Lazy<IEmployeeRepository> (() => new EmployeeRepository(_DbContext));
;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IDepartmentRepository DepartmentRepository =>_departmentRepository.Value;

       

        public int SaveChanges()
        {
           return _DbContext.SaveChanges();
        }

       
    }
}
