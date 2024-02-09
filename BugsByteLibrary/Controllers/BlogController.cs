using Core.Layer.IService;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _blogService.GetAllBlogAsync();
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogDetails(int id)
        {

            var value = await _blogService.GetBlogByIdAsync(id);


            return View(value);
        }
    }
}
