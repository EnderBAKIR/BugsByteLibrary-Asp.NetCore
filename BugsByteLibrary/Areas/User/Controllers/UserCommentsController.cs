using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class UserCommentsController : Controller
    {

        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public UserCommentsController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var comments = await _commentService.GetCommentsByUserIdAsync(user.Id);

            return View(comments);
        }
    }
}
