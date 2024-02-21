using Core.Layer.IRepositories;
using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        private readonly IBlogService _blogService;

        public AdminBlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values =await _blogService.GetAllBlogAsync();
                

            return View(values);
        }

        public async Task<IActionResult> ChangeStatusFalse(Blog blog , int id)
        {
            blog = await _blogService.GetBlogByIdAsync(id);

            blog.Status = false;

            await _blogService.UpdateBlog(blog);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ChangeStatusTrue(Blog blog, int id)
        {
            blog = await _blogService.GetBlogByIdAsync(id);

            blog.Status = true;

            await _blogService.UpdateBlog(blog);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> DeleteBlog(Blog blog , int id)
        {
            blog = await _blogService.GetBlogByIdAsync(id);

            await _blogService.DeleteBlog(blog);

            return RedirectToAction(nameof(Index));

        }
    }
}
