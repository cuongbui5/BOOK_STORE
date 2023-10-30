using System.Security.Claims;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.Controllers;
[Authorize]

public class CartController: Controller
{
    private readonly ICartService cartService;
    private readonly ICartItemService cartItemService;
    private readonly IOrderService orderService;
    private readonly IOrderItemService orderItemService;
    private readonly IAuthService authService;
    private readonly ILogger<CartController> _logger;
    
    public CartController(ICartService cartService,
                          ICartItemService cartItemService,
                          IOrderService orderService,
                          IOrderItemService orderItemService,
                          IAuthService authService
                         )
    {
        this.cartService = cartService;
        this.cartItemService = cartItemService;
        this.orderService = orderService;
        this.orderItemService = orderItemService;
        this.authService = authService;
       
    }

    public IActionResult Pay(int id)
    {
        
        List<CartItem> cartItems = cartItemService.GetCartItemsByCartId(id);
        string username = User.FindFirstValue(ClaimTypes.NameIdentifier);
        User user = authService.GetUserByUsername(username);
        Order order = new Order();
        order.CreatedAt=DateTime.Now;
        order.UserId = user.Id;
        Order newOrder = orderService.CreateOrder(order);


        foreach (CartItem cartItem in cartItems)
        {
            
            OrderItem orderItem = CartItemToOrderItem(cartItem,newOrder.Id);
            orderItemService.CreateOrderItem(orderItem);
        }
        
        
       
        
        cartItemService.DeleteCartItemByCartId(id);
      
        TempData["Message"] = "Order created successful!";
        
        return RedirectToAction("Cart", "Home");
    }

    public OrderItem CartItemToOrderItem(CartItem cartItem,int orderId)
    {
        if (cartItem == null || orderId == null)
        {
            return null;
        }
        OrderItem orderItem = new OrderItem();
        orderItem.BookId = cartItem.BookId;
        orderItem.OrderId = orderId;
        orderItem.Quantity = cartItem.Quantity;
        orderItem.Price = (decimal)(cartItem.Book?.Price ?? 0) * cartItem.Quantity;
        return orderItem;

    }
   
}