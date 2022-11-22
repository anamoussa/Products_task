using Core.Entities;
using Front.viewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Front.Controllers
{
    public class UserController : Controller
    {
        UserManager<User> UserManager;
        SignInManager<User> SignInManager;
        RoleManager<IdentityRole> RoleManager;
        public UserController(UserManager<User> userManager,
             SignInManager<User> _SignInManager,
              RoleManager<IdentityRole> _RoleManager)
        {
            UserManager = userManager;
            SignInManager = _SignInManager;
            RoleManager = _RoleManager;
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.Roles = RoleManager.Roles.ToList()
                .Select(i => new SelectListItem(i.Name, i.Name)).ToList();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (!ModelState.IsValid)
                return View();
            else
            {
                User User = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                IdentityResult result =
                await UserManager.CreateAsync(User, model.Password);
                await UserManager.AddToRoleAsync(User, model.Role);
                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(
                        i =>
                        {
                            ModelState.AddModelError("", i.Description);
                        }
                        );
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Product");
                }
            }
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();
            else
            {
               

                var result =
                await SignInManager.PasswordSignInAsync(model.Email, model.Password,
                        model.RememberMe, true);

                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Invalid User Name Or password");
                    return View();
                }
                else
                {

                    return RedirectToAction("Index", "Product");
                }
            }

        }


        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
