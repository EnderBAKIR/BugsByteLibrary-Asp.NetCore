using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Controllers
{
    public class MailConfirmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
