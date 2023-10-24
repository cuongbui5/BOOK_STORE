using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Services;

public interface ICartItemService
{
    CartItem CreateCartItem(CartItem cartItem);
    void UpdateCartItem(CartItem cartItem);
    List<CartItem> GetCartItemsByCartId(int cartId);
    void DeleteCartItemByCartId(int cartId);
}