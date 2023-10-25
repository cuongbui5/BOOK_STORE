using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repository;

public interface ICartRepository
{
    Cart CreateCart(Cart cart);
    void DeleteCartById(int cartId);
    Cart GetCartByUserUserName(string username);
    Cart GetCartById(int id);
}