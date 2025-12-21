using Microsoft.AspNetCore.Mvc;

namespace DemoG03.ResentationLayer.Controllers
{
    public class AccountController : Controller 
    {
      public IActionResult Register()
        {
            return View();
        }
    }
}
