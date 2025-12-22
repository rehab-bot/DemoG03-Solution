using DemoG03.DataAccess.Models.IdentityModels;
using DemoG03.ResentationLayer.Utities;
using DemoG03.ResentationLayer.ViewModels.AccountViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoG03.ResentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(registerViewModel.UserName).Result;
                if (user is null)
                {
                    user = new ApplicationUser
                    {
                        FirstName = registerViewModel.FirstName,
                        LastName = registerViewModel.LastName,
                        UserName = registerViewModel.UserName,
                        Email = registerViewModel.Email,

                    };
                    var result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "UserName is already exists , try another one");

                }
            }
            return View(registerViewModel);
        }


        #endregion

        #region login
        public IActionResult CheckYourInbox()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CheckYourInbox(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(loginViewModel.Email).Result;
                if (user is not null)
                {
                    var flag = _userManager.CheckPasswordAsync(user, loginViewModel.Password).Result;
                    if (flag)
                    {
                        var result = _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                        if (result.IsNotAllowed)
                        {
                            ModelState.AddModelError(string.Empty, "You are not allowed to login");
                        }
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError(string.Empty, "Your account is locked out");
                        }
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid Email or  Password");
                        }
                    }

                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Email or  Password");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login");
                }
            }
            return View(loginViewModel);
        }
        #endregion

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction(nameof(Logout));
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }

        public IActionResult ResetPassword(string email ,string token)
        {
            TempData["email"] = email;
            TempData["token"] = token;

            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid) return View(resetPasswordViewModel);
            string email = TempData["email"]?.ToString() ?? string.Empty;
            string token = TempData["token"]?.ToString() ?? string.Empty;
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user is not null)
            {
                var result = _userManager.ResetPasswordAsync(user, token, resetPasswordViewModel.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else

                    foreach (var error in result.Errors)

                    { ModelState.AddModelError(string.Empty, error.Description);

                    }
            

            }
            
            return View(resetPasswordViewModel);
        }

    } 
}
