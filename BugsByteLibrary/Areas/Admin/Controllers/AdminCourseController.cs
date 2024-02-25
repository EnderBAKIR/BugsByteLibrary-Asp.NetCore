using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Layer.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCourseController : Controller
    {

        private readonly ICourseRequestService _courseService;

        private readonly ICourseCodeService _courseCodeService;

        public AdminCourseController(ICourseRequestService courseService, ICourseCodeService courseCodeService)
        {
            _courseService = courseService;
            _courseCodeService = courseCodeService;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCourseAsync();

            return View(courses);
        }

        public async Task<IActionResult>GetCourseDetails(string id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            TempData["courseId"] = course.Id;

            return View(course);
        }


        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseRequest course)
        {
            await _courseService.AddCourseAsync(course);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCourse(string id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(CourseRequest course, string id)
        {
            

            course.Status = true;
            await _courseService.UpdateCourseAsync(course);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteCourse(CourseRequest course , string id)
        {
            course = await _courseService.GetCourseByIdAsync(id);

            await _courseService.DeleteCourseAsync(course);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeStatusFalse(CourseRequest course, string id)
        {
            course = await _courseService.GetCourseByIdAsync(id);
            course.Status = false;

            await _courseService.UpdateCourseAsync(course);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ChangeStatusTrue(CourseRequest course, string id)
        {
            course = await _courseService.GetCourseByIdAsync(id);
            course.Status = true;

            await _courseService.UpdateCourseAsync(course);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> AddCode(string id , CourseCode courseCode)
        {
            
            

            await _courseCodeService.UpdateCourseCodeAsync(courseCode);

            return RedirectToAction(nameof(GetCourseDetails) , new {id = TempData["courseId"] });

        }

    }
}
