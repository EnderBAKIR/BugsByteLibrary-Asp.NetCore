using BugsByteLibrary.Controllers;
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
            var userMail = await _userManager.FindByNameAsync(User.Identity.Name);

            // Eğer kullanıcı e-posta doğrulaması yapmamışsa, kullanıcıyı mail doğrulama işlemine atıcak
            if (!userMail.EmailConfirmed)
            {
                return RedirectToAction(nameof(MailConfirmController.Index), "MailConfirm");
            }



            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var comments = await _commentService.GetCommentsByUserIdAsync(user.Id);

            return View(comments);
        }


        public async Task<IActionResult> DeleteComment(Comment comment , int commentId)//burada aslında gerçekte kullanıcı yorumunu silemiycek sadece statusunu false yapıcak. Güvenlik amacı ile yorumların silinmesi engellendi.
        {

            var userMail = await _userManager.FindByNameAsync(User.Identity.Name);

            // Eğer kullanıcı e-posta doğrulaması yapmamışsa, kullanıcıyı mail doğrulama işlemine atıcak
            if (!userMail.EmailConfirmed)
            {
                return RedirectToAction(nameof(MailConfirmController.Index), "MailConfirm");
            }



            comment = await _commentService.GetCommentByIdAsync(comment.Id);

            comment.Status = false;

            await _commentService.UpdateComment(comment);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {

            var userMail = await _userManager.FindByNameAsync(User.Identity.Name);

            // Eğer kullanıcı e-posta doğrulaması yapmamışsa, kullanıcıyı mail doğrulama işlemine atıcak
            if (!userMail.EmailConfirmed)
            {
                return RedirectToAction(nameof(MailConfirmController.Index), "MailConfirm");
            }



            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.userId = user.Id;

            var comment = await _commentService.GetCommentByIdAsync(id);

            return View(comment);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateComment( Comment comment)
        {

            var userMail = await _userManager.FindByNameAsync(User.Identity.Name);

            // Eğer kullanıcı e-posta doğrulaması yapmamışsa, kullanıcıyı mail doğrulama işlemine atıcak
            if (!userMail.EmailConfirmed)
            {
                return RedirectToAction(nameof(MailConfirmController.Index), "MailConfirm");
            }



            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.userId = user.Id;

            comment.UpdateDate = DateTime.Now;
            comment.Status = true;
            await _commentService.UpdateComment(comment);

            return RedirectToAction(nameof(Index));
        }
    }
}
