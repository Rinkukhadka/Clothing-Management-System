using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ProductManagementSystem.Models;
using ProductManagementSystem.ViewModels;

namespace ProductManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        //get
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Product");
            }
            return View(); // return login view
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }

            }
            ModelState.AddModelError("", "Failed to login");
            return View();

        }
        //get
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductManagementSystem.Models.User newuser = new ProductManagementSystem.Models.User();
                newuser.FirstName = registerViewModel.FirstName;
                newuser.LastName = registerViewModel.LastName;
                newuser.UserName = registerViewModel.UserName;
                newuser.Email = registerViewModel.Email;
                newuser.PhoneNumber = registerViewModel.PhoneNumber.ToString();

                var result = await userManager.CreateAsync(newuser, registerViewModel.Password);
                if(result.Succeeded)
                {
                    if(newuser.UserName == "Admin")
                    {
                        await userManager.AddToRoleAsync(newuser, "Admin");
                        await userManager.AddToRoleAsync(newuser, "Customer");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(newuser, "Customer");
                    }
                    return RedirectToAction("Login", "Account");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerViewModel);
        }

        public async Task<IActionResult>LogOut()
            {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
