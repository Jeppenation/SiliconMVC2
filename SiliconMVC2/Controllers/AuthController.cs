using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconMVC2.ViewModels;

namespace SiliconMVC2.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly AppDataContext _context;

        #region SignUp
        [Route("/SignUp")]
        public IActionResult SignUp()
        {
            var model = new SignUpViewModel
            {
                Title = "Sign Up"
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(!await _context.Users.AnyAsync(u => u.Email == model.Email))
                {
                    var user = new UserEntity
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserName = model.Email
                    };

                    if((await _userManager.CreateAsync(user, model.Password)).Succeeded)
                    {
                        if ((await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false)).Succeeded)
                        {
                            return LocalRedirect("/");
                        }
                        else
                        {
                            return LocalRedirect("/Account/SignIn");
                        }
                    }
                    else
                    {
                        ViewData["StatusMessage"] = "An error occurred while creating the user.";
                    }
                    
                }
                else
                {
                    ViewData["StatusMessage"] = "Email already exists.";
                }
            }
            return View(model);
        }

        #endregion


        #region SignIn
        [Route("/SignIn")]
        public IActionResult SignIn(string returnUrl)
        {
            var model = new SignInViewModel
            {
                Title = "Sign In"
            };

            ViewData["ReturnUrl"] = returnUrl ?? "/";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
        {
           if (ModelState.IsValid)
            {
                if((await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsPersistent, false)).Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
            }

            ViewData["ReturnUrl"] = returnUrl;
            ViewData["StatusMessage"] = "Invalid login attempt.";
            return View(model);
        }

        #endregion

        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Home", "Home");
        }
    }
}
