using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Layer.FluentValidations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BugsByteLibrary.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class UserBlogController : Controller
    {

        private readonly IBlogService _blogservice;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;

        public UserBlogController(IBlogService blogservice, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _blogservice = blogservice;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _blogservice.GetAllBlogAsync();

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                ViewBag.UserId = user.Id;
                return View(value);
            }

            return View();


        }


        [HttpGet]
        public async Task<IActionResult> AddBlog(Blog blog)
        {

            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//categorileri bir checkbox nesnesine atayabilmek için



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog, List<int> SelectedCategoryIds)
        {
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//categorileri bir checkbox nesnesine atayabilmek için

            if (blog.Image != null)

            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(blog.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/blogsimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await blog.Image.CopyToAsync(stream);
                blog.ImageUrl = imagename;
            }


            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            blog.AppUserId = user.Id;
            blog.CreatedDate = DateTime.Now;
            blog.Status = true;


            blog.BlogCategories = SelectedCategoryIds.Select(categoryId => new BlogCategory
            {
                CategoryId = categoryId
            }).ToList();

            var validator = new BlogValidator();
            var validationResult = validator.Validate(blog);

            if (!validationResult.IsValid)
            {
                
                
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(blog);
            }


            await _blogservice.AddBlogAsnyc(blog);
            return RedirectToAction(nameof(Index));





        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {

            var blog = await _blogservice.GetBlogByIdAsync(id);

            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//categorileri bir checkbox nesnesine atayabilmek için

            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            ViewBag.UserId = user.Id;

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Blog blog, List<int> SelectedCategoryIds)
        {

            blog.UpdateDate = DateTime.Now;
            blog.Status = true;

            await _blogservice.DeleteBlogCategoriesAsync(blog);//önce seçili kategorileri silmek için bu metodu kullanıyoruz eğer silmezsek güncellerken hata alırız

            blog.BlogCategories = SelectedCategoryIds.Select(categoryId => new BlogCategory
            {
                CategoryId = categoryId
            }).ToList();

            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//Model state İsvalid değil ise viewbagi tekrar alabilmek için
            var validator = new BlogValidator();
            var validationResult = validator.Validate(blog);

            if (!validationResult.IsValid)
            {


                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(blog);
            }




            await _blogservice.UpdateBlogCategoriesAsync(blog);//sonra seçili kategorileri güncelle

            await _blogservice.UpdateBlog(blog);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> DeleteBlog(int id)
        {

            var blog = await _blogservice.GetBlogByIdAsync(id);
            await _blogservice.DeleteBlog(blog);
            return RedirectToAction(nameof(Index));

        }
    }
}
