using DemoG03.BusinessLogic.DTOs.Employees;
using DemoG03.BusinessLogic.Services.interfaces;
using DemoG03.DataAccess.Models.Employees;
using Microsoft.AspNetCore.Mvc;

namespace DemoG03.ResentationLayer.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IWebHostEnvironment _env;


        public EmployeesController(IEmployeeServices employeeServices,
           ILogger<EmployeesController> logger,
           IWebHostEnvironment env)
        {
            _employeeServices = employeeServices;
            _logger = logger;
            _env = env;
        }
        public IActionResult Index()
        {
            var employees = _employeeServices.GetAllEmployees();
            return View(employees);

        }
        public IActionResult Create(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDTO employeeDTO)
        {//server side validation
            if (ModelState.IsValid)
            {
                try
                {
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
            return View(employeeDTO);

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
            return View(new UpdatedEmployeeDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType)
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int? id ,UpdatedEmployeeDTO employeeDTO)
        {
            if (id is null|| id != employeeDTO.Id)
                return BadRequest();
            if(ModelState.IsValid)
            {

                try
                {
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
            return View(employeeDTO);

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
    

