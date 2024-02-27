using Core.Layer.IService;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.ViewComponents.Blogs
{
    public class _LastThreeBlogs : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _LastThreeBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var blogs = await _blogService.GetLastSixBlogAsync(id);


            return View(blogs);
        }
    }
}
