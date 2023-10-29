using System.Security.Claims;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.Controllers;
[Authorize]
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
        bool bookExistsInCart = false;
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
        else
        {
            List<CartItem> cartItems = cartItemService.GetCartItemsByCartId(cartCurrent.Id);
            
            foreach (var item in cartItems)
            {
                if (item.BookId == bookId)
                {
                    bookExistsInCart = true;
                    break;

                }

                
            }
        }

        if (bookExistsInCart)
        {
            TempData["ErrorMessage"] = "The book already exists in the shopping cart!";
            return RedirectToAction("Detail", "Home",new { bookId = bookId });
        }
        
        
        

        CartItem cartItem = new CartItem();
        cartItem.BookId = bookId;
        cartItem.CreatedAt=DateTime.Now;
        cartItem.Quantity = 1;
        cartItem.CartId = cartCurrent.Id;
       
        cartItemService.CreateCartItem(cartItem);
        TempData["SuccessMessage"] = "The book has been added to the cart!";
        
        return RedirectToAction("Detail", "Home",new { bookId = bookId });


    }

    public IActionResult UpdateQuantityUp(int id)
    {
        CartItem cartItem = cartItemService.GetCartItemById(id);
        cartItem.Quantity +=1;
        cartItemService.UpdateCartItem(cartItem);
        return RedirectToAction("Cart", "Home");
    }
    public IActionResult UpdateQuantityDown(int id)
    {
        CartItem cartItem = cartItemService.GetCartItemById(id);
        cartItem.Quantity -= 1;
        cartItemService.UpdateCartItem(cartItem);
        return RedirectToAction("Cart", "Home");
    }
    
    public IActionResult DeleteCartItem(int id)
    {
        cartItemService.DeleteCartItemById(id);
        return RedirectToAction("Cart", "Home");
    }
}