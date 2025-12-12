
using DemoG03.DataAccess.Data.Contexts;
using DemoG03.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.DataAccess.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext _DbContext;
        public DepartmentRepository(ApplicationDBContext dbContext)
        {
            _DbContext = dbContext;
        }


        //CRUD Operations
        public IEnumerable<Department>GetAll(bool WithTracking = false)
        {
            var departments = _DbContext.Departments.ToList();
            return departments;
        }
        public Department? GetById(int id)
        {
            var department = _DbContext.Departments.Find(id);
            return department;
        }
        public int Add(Department department)
        {
            _DbContext.Departments.Add(department);
            return _DbContext.SaveChanges();
        }
        public int Update(Department department)
        {
            _DbContext.Departments.Update(department);
            return _DbContext.SaveChanges();
        }
        public int Delete(Department department)
        {
            _DbContext.Departments.Remove(department);
            return _DbContext.SaveChanges();
        }
    }
}
