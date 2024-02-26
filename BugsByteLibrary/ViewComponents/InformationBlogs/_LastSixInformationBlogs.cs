using Core.Layer.IService;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.ViewComponents.InformationBlogs
{
    public class _LastSixInformationBlogs : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _LastSixInformationBlogs(IBlogService blogService)
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
