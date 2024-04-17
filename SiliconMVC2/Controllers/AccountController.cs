using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconMVC2.ViewModels;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace SiliconMVC2.Controllers
{
    public class AccountController(UserManager<UserEntity> userManager, AppDataContext context) : Controller
    {
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly AppDataContext _context = context;

        [Authorize]

        public async Task<IActionResult> Details()
        {
            var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var user = await _context.Users.Include(u => u.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifier);

            var model = new AccountDetailsViewModel 
            { 
                BasicInfo = new AccountBasicInfo
                {
                    FirstName = user!.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.Email!,
                    Phone = user.PhoneNumber,
                    Bio = user.Bio,
                    ProfileImage = user.ProfilePicture
                },
                AddressInfo = new AccountAddressInfo
                {
                    AddressLine_1 = user.Address?.AddressLine1 ?? "",
                    AddressLine_2 = user.Address?.AddressLine2,
                    City = user.Address?.City ?? "",
                    PostalCode = user.Address?.PostalCode ?? ""
                }
            }
            ;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasicInfo(AccountDetailsViewModel model)
        {
            if (model.BasicInfo != null)
            {
                if (model.BasicInfo.FirstName != null && model.BasicInfo.LastName != null && model.BasicInfo.EmailAddress != null)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        user.FirstName = model.BasicInfo.FirstName;
                        user.LastName = model.BasicInfo.LastName;
                        user.Email = model.BasicInfo.EmailAddress;
                        user.PhoneNumber = model.BasicInfo.Phone;
                        user.Bio = model.BasicInfo.Bio;
                        user.ProfilePicture = model.BasicInfo.ProfileImage;

                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            TempData["StatusMessage"] = "Basic info updated successfully.";
                        }
                        else
                        {
                            TempData["StatusMessage"] = "Basic info could not be updated.";
                        }
                    }
                }
                
            }
            else
            {
                TempData["StatusMessage"] = "Basic info could not be updated.";

            }
            return RedirectToAction("Details", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAddressInfo(AccountDetailsViewModel model)
        {
            try
            {
                if (model.AddressInfo != null)
                {
                    if(model.AddressInfo.AddressLine_1 != null && model.AddressInfo.City != null && model.AddressInfo.PostalCode != null)
                    {
                        var user = await _userManager.GetUserAsync(User);
                        if (user != null)
                        {
                            if (user.Address == null)
                            {
                                user.Address = new AddressEntity();
                            }
                            user.Address.AddressLine1 = model.AddressInfo.AddressLine_1;
                            user.Address.AddressLine2 = model.AddressInfo.AddressLine_2;
                            user.Address.City = model.AddressInfo.City;
                            user.Address.PostalCode = model.AddressInfo.PostalCode;

                            var result = await _userManager.UpdateAsync(user);
                            if (result.Succeeded)
                            {
                                TempData["StatusMessage"] = "Address info updated successfully.";
                            }
                            else
                            {
                                TempData["StatusMessage"] = "Address info could not be updated.";
                            }
                        }
                    }
                    else
                    {
                        TempData["StatusMessage"] = "Address info could not be updated.";
                    }
                    

                }


            }
            catch
            {
                TempData["StatusMessage"] = "Address info could not be updated.";
            }


            
            return RedirectToAction("Details", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null && file != null && file.Length != 0)
            {
                var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/uploads/Profiles", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                user.ProfilePicture = fileName;

                await _userManager.UpdateAsync(user);
            }
            else
            {
                TempData["StatusMessage"] = "Profile image could not be uploaded.";
            }

            return RedirectToAction("Details", "Account");
        }
    }
}
