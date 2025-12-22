using DemoG03.BusinessLogic.DTOs.Employees;
using DemoG03.BusinessLogic.Services.interfaces;
using DemoG03.DataAccess.Models.Employees;
using DemoG03.ResentationLayer.ViewModels.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoG03.ResentationLayer.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IDepartmentServices _departmentServices;


        public EmployeesController(IEmployeeServices employeeServices,
           ILogger<EmployeesController> logger,
           IWebHostEnvironment env,
          IDepartmentServices departmentServices  )
        {
            _employeeServices = employeeServices;
            _logger = logger;
            _env = env;
            _departmentServices = departmentServices;
        }
        public IActionResult Index()
        {
            var employees = _employeeServices.GetAllEmployees();
            return View(employees);

        }
        public IActionResult Create() 
        {
            ViewData["Departments"] = _departmentServices.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {//server side validation
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDTO = new CreatedEmployeeDTO()
                    {
                        Name = employeeVM.Name,
                        Age = employeeVM.Age,
                        Address = employeeVM.Address,
                        Salary = employeeVM.Salary,
                        IsActive = employeeVM.IsActive,
                        Email = employeeVM.Email,
                        PhoneNumber = employeeVM.PhoneNumber,
                        Image = employeeVM.Image,
                    };
                    var result = _employeeServices.CreateEmployee(employeeDTO);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Can't Create Employee Right now");
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }

            }
            return View(employeeVM);

        }
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();


            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound();
            return View(new EmployeeViewModel()
            {
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                DepartmentId = employee.DepartmentId    
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int? id ,EmployeeViewModel employeeVM)
        {
            if (id is null)
                return BadRequest();
            
            if (ModelState.IsValid)
            {

                try
                {
                    var employeeDTO = new UpdatedEmployeeDTO()
                    {
                        Id = id.Value,
                        Name = employeeVM.Name,
                        Age = employeeVM.Age,
                        Address = employeeVM.Address,
                        Salary = employeeVM.Salary,
                        IsActive = employeeVM.IsActive,
                         Email = employeeVM.Email,
                        PhoneNumber = employeeVM.PhoneNumber,
                        HiringDate = employeeVM.HiringDate,
                        DepartmentId = employeeVM.DepartmentId
                    };
                        var result = _employeeServices.UpdateEmployee(employeeDTO);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee is not updated ");
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(employeeVM  );

        }
        public IActionResult Delete([FromRoute] int? id)
        {
            if (id is null)
                return BadRequest();
            try
            {
                var result = _employeeServices.DeleteEmployee(id.Value);
                if (result)
                    return RedirectToAction(nameof(Index));
                else
                    _logger.LogError("Employee is not deleted ");


            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                {
                    _logger.LogError(ex.Message);
                }
            }
            return RedirectToAction(nameof(Index));

        }

    }
}
    

