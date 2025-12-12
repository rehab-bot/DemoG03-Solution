using DemoG03.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoG03.ResentationLayer.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        public DepartmentsController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartments(); 
            return View();
        }
    }
}
 