using DAL.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels.AccountViewModels;

namespace PL.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager) : Controller
    {
        #region Register

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerView)
        {
            if(!ModelState.IsValid) return View(registerView);
            var User = new ApplicationUser()
            {
                FirstName = registerView.FirstName,
                LastName = registerView.LastName,
                UserName = registerView.UserName,
                Email = registerView.Email
            };
            var result = _userManager.CreateAsync(User, registerView.Password).Result;
            if(result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerView);
            }
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public IActionResult Login(LoginViewModel loginView)
        {
            if (!ModelState.IsValid) return View(loginView);
            var User = _userManager.FindByEmailAsync(loginView.Email).Result;
            if (User is not null)
            {
                var result = _signInManager.PasswordSignInAsync(User, loginView.Password, loginView.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt:(");

                }

            }
            return View(loginView);
        }
        #endregion
    }
}
