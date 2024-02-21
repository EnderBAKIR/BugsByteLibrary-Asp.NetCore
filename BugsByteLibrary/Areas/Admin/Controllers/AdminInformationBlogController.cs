﻿using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Layer.Services;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminInformationBlogController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogservice;

        public AdminInformationBlogController(ICategoryService categoryService, IBlogService blogservice)
        {
            _categoryService = categoryService;
            _blogservice = blogservice;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _blogservice.GetAllBlogAsync();
            
            return View(values);
            

            
        }


        [HttpGet]
        public async Task<IActionResult> AddBlog()
        {

            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//categorileri bir checkbox nesnesine atayabilmek için



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog, List<int> SelectedCategoryIds)
        {


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
            blog.InformationBlog = true;


            blog.BlogCategories = SelectedCategoryIds.Select(categoryId => new BlogCategory
            {
                CategoryId = categoryId
            }).ToList();



            await _blogservice.AddBlogAsnyc(blog);
            return RedirectToAction(nameof(Index));





        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {

            var blog = await _blogservice.GetBlogByIdAsync(id);
            
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();//categorileri bir checkbox nesnesine atayabilmek için


            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Blog blog, List<int> SelectedCategoryIds)
        {

            
            blog.UpdateDate = DateTime.Now;
            blog.Status = true;
            blog.InformationBlog = true;

            await _blogservice.DeleteBlogCategoriesAsync(blog);//önce seçili kategorileri silmek için bu metodu kullanıyoruz eğer silmezsek güncellerken hata alırız

            blog.BlogCategories = SelectedCategoryIds.Select(categoryId => new BlogCategory
            {
                CategoryId = categoryId
            }).ToList();

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




        public async Task<IActionResult> ChangeStatusFalse(Blog blog, int id)
        {
            blog = await _blogservice.GetBlogByIdAsync(id);
            blog.Status = false;

            await _blogservice.UpdateBlog(blog);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ChangeStatusTrue(Blog blog, int id)
        {
            blog = await _blogservice.GetBlogByIdAsync(id);
            blog.Status = true;

            await _blogservice.UpdateBlog(blog);
            return RedirectToAction(nameof(Index));
        }
    }
}
