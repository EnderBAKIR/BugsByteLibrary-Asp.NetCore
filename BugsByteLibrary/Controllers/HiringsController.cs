using Core.Layer.IService;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Controllers
{
    public class HiringsController : Controller
    {
        private readonly IHiringService _hiringService;

        public HiringsController(IHiringService hiringService)
        {
            _hiringService = hiringService;
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
    }
}
