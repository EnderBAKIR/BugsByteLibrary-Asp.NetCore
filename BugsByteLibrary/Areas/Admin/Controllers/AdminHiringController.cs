using Core.Layer.IService;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    public class AdminHiringController : Controller
    {
        private readonly IHiringService _hiringService;


        public async Task<IActionResult> Index()
        {


            return View();
        }
    }
}
