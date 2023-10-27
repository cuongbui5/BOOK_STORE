using BOOK_STORE_DEMO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using BOOK_STORE_DEMO.Dtos.Response;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Authorization;
using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICartItemService cartItemService;
        private readonly IAuthService authService;
        private readonly ICartService cartService;
       

        public HomeController(IBookService bookService, ICartItemService cartItemService,IAuthService authService,ICartService cartService)
        {
            this.bookService = bookService;
            this.cartItemService = cartItemService;
            this.authService = authService;
            this.cartService = cartService;
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
        public IActionResult Cart()
        {
            string username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (String.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Auth");
            }

            Cart cart = cartService.GetCartByUserUserName(username);
            if (cart == null)
            {
                Cart newCart = new Cart();
                User user = authService.GetUserByUsername(username);
                newCart.UserId = user.Id;
                cart = cartService.CreateCart(newCart);
            }
           

            IEnumerable<CartItem> cartItems = cartItemService.GetCartItemsByCartId(cart.Id);
           
            decimal totalAmount = 0;
            foreach (var i in cartItems)
            {
                
                decimal price = (decimal)(i.Book?.Price ?? 0);
                totalAmount += price * i.Quantity;
            }
            CartResponse cartResponse = new CartResponse();
            cartResponse.Id = cart.Id;
            cartResponse.CartItems = cartItems;
            cartResponse.Total = totalAmount;
            
           
            return View(cartResponse);
        }
    }
}