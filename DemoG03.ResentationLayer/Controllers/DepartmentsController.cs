using DemoG03.BusinessLogic.DTOs.Departments;
using DemoG03.BusinessLogic.Services.interfaces;
using DemoG03.ResentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace DemoG03.ResentationLayer.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
       private readonly ILogger<DepartmentsController> _logger;
        private readonly IWebHostEnvironment _env;

        public DepartmentsController(IDepartmentServices departmentServices,
            ILogger<DepartmentsController> logger,
            IWebHostEnvironment env)
        {  
            _departmentServices = departmentServices; 
            _env = env;
        }
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartments(); 
            return View(departments);
        }
        [HttpGet]
       
         public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO departmentDTO)
        { 
            if(!ModelState.IsValid)
            {
                return View(departmentDTO);

            }
            var message =string.Empty;
            try
            {
                var result = _departmentServices.AddDepartment(departmentDTO);
                if (result > 0)
                    return RedirectToAction(nameof(Index));   
                //View("Index",_departmentServices.GetAllDepartments());
                else
                {
                    message = "Department cannot be created ";
                    ModelState.AddModelError(string.Empty, message);
                    return View(departmentDTO);
                }
            }
            catch (Exception ex) 
            { 
                _logger.LogError(ex,ex.Message);
                if (_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentDTO);
                }
                else
                {
                    message = "Department cannot be Created";
                    return View("Error",message);
                }
             }
                  
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id is null)

            { 
                return BadRequest();
            
            }
            var department = _departmentServices.GetDepartmentById(id.Value);
            if(department is null)
            {
                return NotFound();
            }
            return View(new DepartmentViewModel()
            {  
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
              DateOfCreation = department.DateOfCreation,
            });

        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id,DepartmentViewModel departmetMV)
        {   if (!ModelState.IsValid)
            {
                {
                    return View(departmetMV);
                }
            }
                var message =string.Empty;
            try
            {
                var result = _departmentServices.UpdateDepartment(new UpdatedDepartmentDTO()

                {
                    Id = id,
                    Code = departmetMV.Code,
                    Name = departmetMV.Name,
                    Description = departmetMV.Description,
                    DateOfCreation = departmetMV.DateOfCreation


                });
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Department can't be updated";
                   
                }
            }
            catch (Exception ex)
            {
                message = _env.IsDevelopment() ? ex.Message : "Department can't be updated";
            }
                return View(departmetMV);

            }
        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id is null)

            {
                return BadRequest();

            }
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var result = _departmentServices.DeleteDepartment(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    message = "an Error happened when deleting the department";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                message = _env.IsDevelopment() ? ex.Message : "an Error happened when deleting the department";
            }
            return View(nameof(Index));



        }   }
}
 