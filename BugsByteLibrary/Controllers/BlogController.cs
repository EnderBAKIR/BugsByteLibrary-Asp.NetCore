using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;

namespace BugsByteLibrary.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        private readonly UserManager<AppUser> _userManager;

        private readonly ICommentService _commentService;

        public BlogController(IBlogService blogService, UserManager<AppUser> userManager, ICommentService commentService)
        {
            _blogService = blogService;
            _userManager = userManager;
            _commentService = commentService;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(int blogId, Comment comment)
        {

            await _commentService.AddCommentAsync(comment);
            return RedirectToAction("GetBlogDetails", "Blog", new { id = blogId });
        }
    }
}
