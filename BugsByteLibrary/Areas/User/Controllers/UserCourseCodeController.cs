using BugsByteLibrary.Controllers;
using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class UserCourseCodeController : Controller
    {
        private readonly ICourseCodeService _courseCodeService;
        private readonly UserManager<AppUser> _userManager;

        public UserCourseCodeController(ICourseCodeService courseCodeService, UserManager<AppUser> userManager)
        {
            _courseCodeService = courseCodeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var userMail = await _userManager.FindByNameAsync(User.Identity.Name);

            // Eğer kullanıcı e-posta doğrulaması yapmamışsa, kullanıcıyı mail doğrulama işlemine atıcak
            if (!userMail.EmailConfirmed)
            {
                return RedirectToAction(nameof(MailConfirmController.Index), "MailConfirm");
            }


            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var courseCodes = await _courseCodeService.GetCourseCodeByUserIdAsync(user.Id);

            return View(courseCodes);
        }
    }
}
