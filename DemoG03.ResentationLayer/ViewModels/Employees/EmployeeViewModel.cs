using DemoG03.DataAccess.Models.Employees;
using System.ComponentModel.DataAnnotations;

namespace DemoG03.ResentationLayer.ViewModels.Employees
{
    public class EmployeeViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name should be less than 50 char")]
        [MinLength(3, ErrorMessage = "Name should be at least 3 char")]
        public string Name { get; set; } = null!;
        [Range(24, 40)]
        public int? Age { get; set; }
        //123-Street-City-Country
        [RegularExpression("*[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address Must be like 123-Street-City-Country")]
        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]

        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "DepartmentId")]
        public int? DepartmentId { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public DateOnly HiringDate { get; set; }
        public IFormFile? Image { get; set; }

    }
}
