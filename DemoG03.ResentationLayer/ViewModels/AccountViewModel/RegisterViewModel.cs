using System.ComponentModel.DataAnnotations;

namespace DemoG03.ResentationLayer.ViewModels.AccountViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="First Name Is Required")]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name Is Required")]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "User Name Is Required")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }

        }
}
  