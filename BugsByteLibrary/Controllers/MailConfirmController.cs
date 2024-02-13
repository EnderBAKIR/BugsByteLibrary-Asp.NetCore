using BugsByteLibrary.Models;
using Core.Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Controllers
{
    public class MailConfirmController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MailConfirmController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(MailConfirmViewModel mailConfirmViewModel)
        {

            if (User.Identity.IsAuthenticated)
            {
             var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.mail = user.Email;

                if (user.EmailConfirmed == true)
                {
                    return View();
                }
                if (mailConfirmViewModel.ConfirmCode == user.ConfirmCode)
                {
                    user.EmailConfirmed=true;
                    await _userManager.UpdateAsync(user);
                    return View();
                }
                else
                {
                    return View();
                }
                
            }
            return RedirectToAction("Login", "Account");


            
        }
    }
}
