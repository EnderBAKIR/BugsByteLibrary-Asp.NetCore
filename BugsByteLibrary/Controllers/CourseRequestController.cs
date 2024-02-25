using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Controllers
{
    public class CourseRequestController : Controller
    {

        private readonly ICourseRequestService _courseRequestService;
        private readonly ICourseCodeService _courseCodeService;
        private readonly UserManager<AppUser> _userManager;

        public CourseRequestController(ICourseRequestService courseRequestService, ICourseCodeService courseCodeService, UserManager<AppUser> userManager)
        {
            _courseRequestService = courseRequestService;
            _courseCodeService = courseCodeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var courseRequests = await _courseRequestService.GetAllCourseAsync();

            return View(courseRequests);
        }


        public async Task<IActionResult> WantCourseCode(string id , CourseCode courseCode)
        {
            var courseRequest = await _courseRequestService.GetCourseByIdAsync(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            courseCode.AppUserId = user.Id;
            

            await _courseCodeService.AddCourseCodeAsync(courseCode);

            return RedirectToAction(nameof(Index));
            


        }
    }
}
