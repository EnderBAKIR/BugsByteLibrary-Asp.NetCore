using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Layer.Services;

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

        public async Task<IActionResult> GetHiringDetails(string id)
        {
            var hiring = await _hiringService.GetHiringByIdAsync(id);

            return View(hiring);
        }


        [HttpGet]
        public IActionResult AddHiring()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHiring(Hiring hiring)
        {
            await _hiringService.AddHiringAsync(hiring);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateHiring(string id)
        {
            var hiring = await _hiringService.GetHiringByIdAsync(id);

            return View(hiring);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateHiring(Hiring hiring )
        {
            
            hiring.UpdateDate = DateTime.Now;
            hiring.Status = true;
            await _hiringService.UpdateHiringAsync(hiring);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteHiring(string id)
        {
            var hiring = await _hiringService.GetHiringByIdAsync(id);

            await _hiringService.DeleteHiringAsync(hiring);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeStatusFalse(Hiring hiring, string id)
        {
            hiring = await _hiringService.GetHiringByIdAsync(id);
            hiring.Status = false;

            await _hiringService.UpdateHiringAsync(hiring);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ChangeStatusTrue(Hiring hiring, string id)
        {
            hiring = await _hiringService.GetHiringByIdAsync(id);
            hiring.Status = true;

            await _hiringService.UpdateHiringAsync(hiring);
            return RedirectToAction(nameof(Index));

        }

    }
}
