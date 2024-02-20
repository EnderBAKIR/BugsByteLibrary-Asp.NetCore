using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugsByteLibrary.Controllers
{
    public class BooksesController : Controller
    {
        private readonly IBookService _bookService;
        private readonly UserManager<AppUser> _userManager;

        public BooksesController(IBookService bookService, UserManager<AppUser> userManager)
        {
            _bookService = bookService;
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.Users.Include(x => x.Comments).FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
                if (user.Comments != null)
                {
                    ViewBag.CommentCount = user.Comments.Count();//Burada giriş yapan kullanıcının kaç yorumu var onu alıyoruz ona göre kitaplara erişip erişemiyceği belirlenecek.
                }

                
            }

            

            var values= await _bookService.GetAllBookAsync();

            return View(values);
        }
    }
}
