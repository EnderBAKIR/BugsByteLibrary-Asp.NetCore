using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Layer.FluentValidations;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminCodeBankBlogController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogservice;

        public AdminCodeBankBlogController(ICategoryService categoryService, IBlogService blogservice)
        {
            _categoryService = categoryService;
            _blogservice = blogservice;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var values = await _blogservice.GetAllBlogAsync();

            return View(values);



        }


        [HttpGet]
        public async Task<IActionResult> AddBlog()
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//categorileri bir checkbox nesnesine atayabilmek için



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog, List<int> SelectedCategoryIds)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

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




            blog.CreatedDate = DateTime.Now;
            blog.Status = true;
            blog.CodeBank = true;


            blog.BlogCategories = SelectedCategoryIds.Select(categoryId => new BlogCategory
            {
                CategoryId = categoryId
            }).ToList();

            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//categorileri bir checkbox nesnesine atayabilmek için

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
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var blog = await _blogservice.GetBlogByIdAsync(id);

            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//categorileri bir checkbox nesnesine atayabilmek için


            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Blog blog, List<int> SelectedCategoryIds)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            blog.UpdateDate = DateTime.Now;
            blog.Status = true;
            blog.CodeBank = true;

            await _blogservice.DeleteBlogCategoriesAsync(blog);//önce seçili kategorileri silmek için bu metodu kullanıyoruz eğer silmezsek güncellerken hata alırız

            blog.BlogCategories = SelectedCategoryIds.Select(categoryId => new BlogCategory
            {
                CategoryId = categoryId
            }).ToList();

            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//categorileri bir checkbox nesnesine atayabilmek için
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
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var blog = await _blogservice.GetBlogByIdAsync(id);
            await _blogservice.DeleteBlog(blog);
            return RedirectToAction(nameof(Index));

        }




        public async Task<IActionResult> ChangeStatusFalse(Blog blog, int id)
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            blog = await _blogservice.GetBlogByIdAsync(id);
            blog.Status = false;

            await _blogservice.UpdateBlog(blog);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ChangeStatusTrue(Blog blog, int id)
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            blog = await _blogservice.GetBlogByIdAsync(id);
            blog.Status = true;

            await _blogservice.UpdateBlog(blog);
            return RedirectToAction(nameof(Index));
        }
    }
}
