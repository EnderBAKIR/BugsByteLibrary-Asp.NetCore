﻿using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.User.Controllers
{

    [Area("User")]
    public class UserBlogController : Controller
    {

        private readonly IBlogService _blogservice;
        private readonly UserManager<AppUser> _userManager;

        public UserBlogController(IBlogService blogservice, UserManager<AppUser> userManager)
        {
            _blogservice = blogservice;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _blogservice.GetAllBlogAsync();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            ViewBag.UserId = user.Id;
            return View(value);
        }


        [HttpGet]
        public async Task<IActionResult> AddBlog()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            ViewBag.UserId = user.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog)
        {



            blog.CreatedDate = DateTime.Now;
            blog.Status = true;
            await _blogservice.AddBlogAsnyc(blog);
            return RedirectToAction(nameof(Index));





        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {

            var blog = await _blogservice.GetBlogByIdAsync(id);



            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            ViewBag.UserId = user.Id;

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {



            blog.UpdateDate = DateTime.Now;
            blog.Status = true;
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