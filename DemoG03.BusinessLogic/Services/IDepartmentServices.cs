using DemoG03.BusinessLogic.DTOs;

namespace DemoG03.BusinessLogic.Services
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreatedDepartmentDTO departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDTO> GetAllDepartments();
        DepartmentDetailsDTO? GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDTO departmentDto);
    }
}