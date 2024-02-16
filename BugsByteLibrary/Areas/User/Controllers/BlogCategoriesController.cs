using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace BugsByteLibrary.Areas.User.Controllers
{
    [Area("User")]
    public class BlogCategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public BlogCategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

           var category = await _categoryService.GetAllCategoryAsync();

            return View(category);
        }


        [HttpGet]
        public IActionResult AddCategory()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {

          await _categoryService.AddCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async  Task<IActionResult> EditCategory(int id , Category category)
        {

            category = await _categoryService.GetByCategoryIdAsync(id);
            return View(category);

        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCategory(Category category , int id)
        {
            category = await _categoryService.GetByCategoryIdAsync(id);

            await _categoryService.DeleteCategoryAsync(category);

            return RedirectToAction(nameof(Index));
            
        }
    }
}
