﻿using Core.Layer.IService;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}