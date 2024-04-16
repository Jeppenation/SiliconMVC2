using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconMVC2.ViewModels;

namespace SiliconMVC2.Controllers
{
    public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AppDataContext context) : Controller
    {
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;
        private readonly AppDataContext _context = context;

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
        [Route("/SignUp")]
        public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email);
                if (exists)
                {
                    ModelState.AddModelError("EmailAddress", "Email address already exists.");
                    ViewData["ErrorMessage"] = "Email address already exists.";
                    return View(viewModel);
                }

                var userEntity = new UserEntity
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    UserName = viewModel.Email
                };

                var result = await _userManager.CreateAsync(userEntity, viewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Auth");
                }

            }



            return View(viewModel);
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
        [Route("/SignIn")]
        public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
        {
           if (ModelState.IsValid)
            {
                if((await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsPersistent, false)).Succeeded)
                    return LocalRedirect(returnUrl);
            }

            ViewData["ReturnUrl"] = returnUrl;
            
            ViewData["StatusMessage"] = "Invalid login attempt.";
            return View(model);
        }

        #endregion

        [Route("/SignOut")]
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Home", "Home");
        }
    }
}
