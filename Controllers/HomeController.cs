using BOOK_STORE_DEMO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BOOK_STORE_DEMO.Dtos.Response;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Authorization;

namespace BOOK_STORE_DEMO.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBookService bookService;
       

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(int?categoryId,int? page)
        {
            int pageNumber = (page ?? 1);
            BookResponse bookResponse =bookService.GetBookByPageAndCategory(categoryId,pageNumber);
            return View(bookResponse);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
        public IActionResult Detail(int bookId)
        {
            Book book = bookService.GetBookById(bookId);
            return View(book);
        }
    }
}