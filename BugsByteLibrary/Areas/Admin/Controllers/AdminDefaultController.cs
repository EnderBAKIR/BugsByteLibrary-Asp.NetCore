using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
