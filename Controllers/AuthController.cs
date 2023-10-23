using System.Security.Claims;
using BOOK_STORE_DEMO.Dtos;
using BOOK_STORE_DEMO.Dtos.Request;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Validate;
using Microsoft.AspNetCore.Mvc;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


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
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }
            User user = authService.Login(loginRequest);
            if (user!=null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim("Role", user.Role)
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = false,
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties);
            }

            if (user.Role == "ADMIN")
            {
                return RedirectToAction("Index","Admin");
            }
            return RedirectToAction("Index","Home");
           
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
   
}
