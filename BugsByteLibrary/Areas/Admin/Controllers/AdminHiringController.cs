using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHiringController : Controller
    {
        private readonly IHiringService _hiringService;

        public AdminHiringController(IHiringService hiringService)
        {
            _hiringService = hiringService;
        }

        public async Task<IActionResult> Index()
        {
            var hirings = await _hiringService.GetAllHiringAsync();

            return View(hirings);
        }

        [HttpGet]
        public  IActionResult AddHiring()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHiring(Hiring hiring)
        {
            await _hiringService.AddHiringAsync(hiring);

            return RedirectToAction(nameof(Index));
        }



    }
}
