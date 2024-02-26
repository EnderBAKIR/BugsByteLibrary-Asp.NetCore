using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Layer.Services;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminCommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public AdminCommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async  Task<IActionResult> Index()
        {


            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var comments = await _commentService.GetAllComment();



            return View(comments);
        }

        public async Task<IActionResult> ChangeStatusFalse(Comment comment , int id)
        {


            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            comment = await _commentService.GetCommentByIdAsync(id);
            comment.Status = false;

            await _commentService.UpdateComment(comment);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ChangeStatusTrue(Comment comment, int id)
        {


            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            comment = await _commentService.GetCommentByIdAsync(id);
            comment.Status = true;

            await _commentService.UpdateComment(comment);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> DeleteComment(int id)
        {


            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            var comment = await _commentService.GetCommentByIdAsync(id);

            await _commentService.DeleteComment(comment);

            return RedirectToAction(nameof(Index));
        }
    }
}
