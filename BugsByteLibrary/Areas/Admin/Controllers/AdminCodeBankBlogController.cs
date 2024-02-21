using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    public class AdminCodeBankBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
