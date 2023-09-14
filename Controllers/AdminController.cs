using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.Controllers;
[Authorize(Policy = "ADMIN")]
public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}