using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Controllers
{
    public class HiringsController : Controller
    {
        private readonly IHiringService _hiringService;
        private readonly IOpenToWorkService _openToWorkService;

        public HiringsController(IHiringService hiringService, IOpenToWorkService openToWorkService)
        {
            _hiringService = hiringService;
            _openToWorkService = openToWorkService;
        }

        public async Task<IActionResult> Index()
        {

            var hirings = await _hiringService.GetAllHiringAsync();


            return View(hirings);
        }


        public async Task<IActionResult> GetHiringDetail(string id)
        {
            var hiring = await _hiringService.GetHiringByIdAsync(id);

            return View(hiring);

        }

        public async Task<IActionResult> AddOpenToWork(OpenToWork openToWork)
        {
            await _openToWorkService.AddOpenToWorkAsync(openToWork);

            return RedirectToAction(nameof(Index));
        }
    }
}
