using DemoG03.DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.DTOs.Employees
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string EmpGender { get; set; } =string.Empty;
        public string EmpEmployeeType { get; set; } = string.Empty;
        [Display(Name = "DepartmentId")]
        public string? DepartmentName { get; set; }


    }
}
