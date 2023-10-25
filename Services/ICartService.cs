using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Services;

public interface ICartService
{
    Cart CreateCart(Cart cart);
    Cart GetCartByUserUserName(string username);

    Cart GetCartById(int id);

}