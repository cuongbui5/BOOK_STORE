using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
