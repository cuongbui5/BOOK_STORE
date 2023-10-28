using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.Controllers;
[Authorize(Policy = "ADMIN")]
public class AdminController : Controller
{
    private readonly IOrderService orderService;
    private readonly IOrderItemService orderItemService;
    public AdminController(IOrderService orderService,IOrderItemService orderItemService)
    {
        this.orderService = orderService;
        this.orderItemService = orderItemService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Order()
    {
        IEnumerable<Order> orders=orderService.getAllOrders();
        return View(orders);
    }

    public IActionResult OrderDetail(int id)
    {
        IEnumerable<OrderItem> orderItems=orderItemService.GetOrderItemsByOrderID(id);
        return View(orderItems);
    }

    public IActionResult DeleteOrder(int id)
    {
        orderItemService.deleteByOrderID(id);
        orderService.deleteByOrderID(id);
        return RedirectToAction("Order");
    }
}