using System.ComponentModel.DataAnnotations;

namespace DemoG03.ResentationLayer.ViewModels.AccountViewModel
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
