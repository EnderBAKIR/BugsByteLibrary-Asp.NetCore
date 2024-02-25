using BugsByteLibrary.Areas.User.Models;
using BugsByteLibrary.Controllers;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

       

        public async Task<IActionResult> Index()
        {

            UserEditViewModel userEditViewModel = new();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            userEditViewModel.UserName = user.UserName;
            userEditViewModel.Name = user.Name;
            userEditViewModel.Surname = user.SurName;
            userEditViewModel.PhoneNumber = user.PhoneNumber;
            userEditViewModel.Email = user.Email;
            ViewBag.ImageUrl = user.ImageUrl;


            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (userEditViewModel.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditViewModel.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await userEditViewModel.Image.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name = userEditViewModel.Name;
            user.SurName = userEditViewModel.Surname;

           

          
            if (userEditViewModel.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
            }
           

            var response = await _userManager.UpdateAsync(user);

            if (response.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            

            return View(userEditViewModel);



        }
    }
}
