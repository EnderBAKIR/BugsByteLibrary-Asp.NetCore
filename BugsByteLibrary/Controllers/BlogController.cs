using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Bcpg;

namespace BugsByteLibrary.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        private readonly ICategoryService _categoryService;

        private readonly UserManager<AppUser> _userManager;

        private readonly ICommentService _commentService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, UserManager<AppUser> userManager, ICommentService commentService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userManager = userManager;
            _commentService = commentService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }

        //Bloglar Categorilere göre listelenecek
        [HttpGet]
        public async Task<IActionResult> GetBlogsByCategory(int id)
        {
            var value = await _categoryService.GetByCategoryIdAsync(id);

            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
           return View(await _blogService.GetAllBlogAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogDetails(int id)
        {

            var value = await _blogService.GetBlogByIdAsync(id);

            TempData["blogId"] = value.Id;

            if (value == null)
            {
                return NotFound();
            }


            return View(value);
        }






        [HttpGet]
        public async Task<IActionResult> GetAllInformationBlogCategory()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
           return View(categories); 
        }
        [HttpGet]
        public async Task<IActionResult> GetInformationBlogByCategory(int id)
        {
            var category = await _categoryService.GetByCategoryIdAsync(id);
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> GetInformationBlogDetails(int id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);


            return View(blog);


        }



        [HttpGet]
        public async Task<IActionResult> GetAllCodeBankBlogCategory()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> GetCodeBankBlogsByCategory(int id)
        {
            var category = await _categoryService.GetByCategoryIdAsync(id);
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> GetCodeBankBlogDetails(int id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);


            return View(blog);


        }





        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(int blogId, Comment comment)
        {

            await _commentService.AddCommentAsync(comment);
            return RedirectToAction("GetBlogDetails", "Blog", new { id = blogId });
        }


        [HttpPost]
        public async Task<IActionResult> AddCommentCodeBank(int blogId, Comment comment)
        {

            await _commentService.AddCommentAsync(comment);
            return RedirectToAction("GetCodeBankBlogDetails", "Blog", new { id = blogId });
        }





        public async Task<IActionResult> ChangeCommentSolverTrue(Comment comment , int id)
        {
            comment = await _commentService.GetCommentByIdAsync(id);

            comment.Status = true;
            comment.SolverComment = true;

            await _commentService.UpdateComment(comment);

            return RedirectToAction(nameof(GetBlogDetails), new { id = TempData["blogId"] });
        }
    }
}
