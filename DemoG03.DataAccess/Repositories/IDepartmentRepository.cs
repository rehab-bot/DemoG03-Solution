using DemoG03.DataAccess.Models;

namespace DemoG03.DataAccess.Repositories
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        IEnumerable<Department>GetAll(bool WithTracking = false);
        int Delete(Department department);
        Department? GetById(int id);
        int Update(Department department);
    }
}