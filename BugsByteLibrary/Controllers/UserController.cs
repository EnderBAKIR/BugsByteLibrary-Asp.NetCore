using Core.Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugsByteLibrary.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            var user = await _userManager.Users.Include(x=>x.Comments).FirstOrDefaultAsync(x=> x.UserName ==User.Identity.Name);


            return View(user);
        }
    }
}
