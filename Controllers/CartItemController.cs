using System.Security.Claims;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.Controllers;

public class CartItemController:Controller
{
    private readonly ICartService cartService;
    private readonly ICartItemService cartItemService;
    private readonly IAuthService authService;
    

    public CartItemController(ICartService cartService, ICartItemService cartItemService,IAuthService authService)
    {
        this.cartService = cartService;
        this.cartItemService = cartItemService;
        this.authService = authService;
    }
    
    
    public IActionResult CreateCartItem(int bookId)
    {
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (String.IsNullOrEmpty(username))
        {
            return RedirectToAction("Login", "Auth");
        }
        Cart cartCurrent = cartService.GetCartByUserUserName(username);
        
        if (cartCurrent == null)
        {
            User user = authService.GetUserByUsername(username);
            Cart cart = new Cart();
            cart.UserId = user.Id;
            cart.User = user;
            cartCurrent = cartService.CreateCart(cart);
        }

        CartItem cartItem = new CartItem();
        cartItem.BookId = bookId;
        cartItem.CreatedAt=DateTime.Now;
        cartItem.Quantity = 1;
        cartItem.CartId = cartCurrent.Id;
        cartItem.Cart = cartCurrent;
        cartItemService.CreateCartItem(cartItem);
        
        return RedirectToAction("Index", "Home");


    }
}