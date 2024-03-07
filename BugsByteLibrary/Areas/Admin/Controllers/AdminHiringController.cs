using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Layer.Services;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminHiringController : Controller
    {
        private readonly IHiringService _hiringService;
        private readonly IOpenToWorkService _openToWorkService;

        public AdminHiringController(IHiringService hiringService, IOpenToWorkService openToWorkService)
        {
            _hiringService = hiringService;
            _openToWorkService = openToWorkService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var hirings = await _hiringService.GetAllHiringAsync();

            return View(hirings);
        }

        public async Task<IActionResult> GetHiringDetails(string id)
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var hiring = await _hiringService.GetHiringByIdAsync(id);

            TempData["hiringId"] = hiring.Id;

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
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            await _hiringService.AddHiringAsync(hiring);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateHiring(string id)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var hiring = await _hiringService.GetHiringByIdAsync(id);

            return View(hiring);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateHiring(Hiring hiring )
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }


            hiring.UpdateDate = DateTime.Now;
            hiring.Status = true;
            await _hiringService.UpdateHiringAsync(hiring);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteHiring(string id)
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var hiring = await _hiringService.GetHiringByIdAsync(id);

            await _hiringService.DeleteHiringAsync(hiring);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeStatusFalse(Hiring hiring, string id)
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            hiring = await _hiringService.GetHiringByIdAsync(id);
            hiring.Status = false;

            await _hiringService.UpdateHiringAsync(hiring);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ChangeStatusTrue(Hiring hiring, string id)
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            hiring = await _hiringService.GetHiringByIdAsync(id);
            hiring.Status = true;

            await _hiringService.UpdateHiringAsync(hiring);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ChangeOpenToWorkStatusFalse(string id)
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var openToWork = await _openToWorkService.GetOpenToWorkByIdAsnc(id);
            openToWork.Status = false;
            await _openToWorkService.UpdateOpenToWorkAsync(openToWork);



            return RedirectToAction(nameof(GetHiringDetails), new { id = TempData["hiringId"] });


        }

        public async Task<IActionResult> ChangeOpenToWorkStatustrue(string id )
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }


            var openToWork = await _openToWorkService.GetOpenToWorkByIdAsnc(id);
            openToWork.Status = true;
            await _openToWorkService.UpdateOpenToWorkAsync(openToWork);

            return RedirectToAction(nameof(GetHiringDetails) , new {id = TempData["hiringId"] });

        }


        public async Task<IActionResult> ChangeOpenToWorkIsConfirmtrue(string id)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }


            var openToWork = await _openToWorkService.GetOpenToWorkByIdAsnc(id);
            openToWork.Status = true;
            openToWork.IsConfirmed = true;
            await _openToWorkService.UpdateOpenToWorkAsync(openToWork);

            return RedirectToAction(nameof(GetHiringDetails), new { id = TempData["hiringId"] });

        }

        public IActionResult DownloadPdf(string pdfName)
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvpdf", pdfName);

            
            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/pdf", pdfName);
            }
            else
            {
               
                return NotFound();
            }
        }

    }
}
