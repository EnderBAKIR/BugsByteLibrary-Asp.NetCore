using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminDefaultController : Controller
    {
        public IActionResult Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }


            return View();
        }
    }
}
