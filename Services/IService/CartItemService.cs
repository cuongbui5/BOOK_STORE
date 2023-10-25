using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Repositories.IRepository;
using BOOK_STORE_DEMO.Repository;

namespace BOOK_STORE_DEMO.Services.IService;

public class CartItemService:ICartItemService
{
    private readonly ICartItemRepository cartItemRepository;

    public CartItemService(ICartItemRepository cartItemRepository)
    {
        this.cartItemRepository = cartItemRepository;
    }

    public CartItem CreateCartItem(CartItem cartItem)
    {
        return cartItemRepository.CreateCartItem(cartItem);
    }

    public CartItem GetCartItemById(int id)
    {
        return cartItemRepository.GetCartItemById(id);
    }

    public void UpdateCartItem(CartItem cartItem)
    {
        cartItemRepository.UpdateCartItem(cartItem);
    }

    public List<CartItem> GetCartItemsByCartId(int cartId)
    {
        return cartItemRepository.GetCartItemsByCartId(cartId);
    }

    public void DeleteCartItemByCartId(int cartId)
    {
        cartItemRepository.DeleteCartItemByCartId(cartId);
    }

    public void DeleteCartItemById(int id)
    {
        cartItemRepository.DeleteCartItemById(id);
    }
}