using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Repository;

namespace BOOK_STORE_DEMO.Services.IService;

public class CartService:ICartService
{
    
    private readonly ICartRepository cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        this.cartRepository = cartRepository;
    }

    public Cart CreateCart(Cart cart)
    {
        
        return cartRepository.CreateCart(cart);
    }

    public Cart GetCartByUserUserName(string username)
    {
        return cartRepository.GetCartByUserUserName(username);
    }
}