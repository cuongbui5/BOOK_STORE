using System.Security.Claims;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Services;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE_DEMO.Controllers;

public class CartController: Controller
{
    private readonly ICartService cartService;
    public CartController(ICartService cartService)
    {
        this.cartService = cartService;
    }
   
}