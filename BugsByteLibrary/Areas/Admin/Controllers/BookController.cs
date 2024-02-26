using Core.Layer.IService;
using Core.Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugsByteLibrary.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }


            return View(await _bookService.GetAllBookAsync());
        }

        public IActionResult AddBook()
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(EBook book)
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }


            if (book.Pdf != null && book.Pdf.Length > 0)
            {
                var pdfExtension = Path.GetExtension(book.Pdf.FileName);
                var pdfName = Guid.NewGuid().ToString() + pdfExtension;
                var pdfFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "bookspdf", pdfName);
                using (var pdfStream = new FileStream(pdfFilePath, FileMode.Create))
                {
                    await book.Pdf.CopyToAsync(pdfStream);
                }
                book.PdfUrl = pdfName;
            }

            await _bookService.AddBookAsync(book);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBook(int id , EBook book) 
        {

            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }


            book = await _bookService.GetBookByIdAsync(id);

             _bookService.DeleteBookAsync(book);

            return RedirectToAction(nameof(Index));

        }
    }
}
