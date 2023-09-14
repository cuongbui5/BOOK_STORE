using BOOK_STORE_DEMO.Dtos;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Validate;
using Microsoft.AspNetCore.Mvc;
using BOOK_STORE_DEMO.Services;


namespace BOOK_STORE_DEMO.Controllers
{
    public class AuthController : Controller
    {
       

        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserDto userDto)
        {
            
            if (userDto.Username!=null&&!Validatator.isEmailValid(userDto.Username))
            {
                ModelState.AddModelError("Email", "Email không hợp lệ");
                return View(userDto);
            }
            
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }
            try
            {
                authService.Register(userDto);   
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
            }
            
            return View(userDto);
        }
    }
}
