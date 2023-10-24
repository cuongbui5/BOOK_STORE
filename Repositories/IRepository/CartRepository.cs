using BOOK_STORE_DEMO.Data;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Repository;

namespace BOOK_STORE_DEMO.Repositories.IRepository;

public class CartRepository:ICartRepository
{
    private readonly BookStoreDBContext context;
    public CartRepository(BookStoreDBContext context)
    {
        this.context = context;
    }

    public Cart CreateCart(Cart cart)
    {
        
        var entityEntry = context.Carts.Add(cart);
        context.SaveChanges();
    
        
        Cart newCart = entityEntry.Entity;

        return newCart;
    }

    public void DeleteCartById(int cartId)
    {
        Cart cart = context.Carts.Find(cartId);
        if (cart != null)
        {
            context.Carts.Remove(cart);
            context.SaveChanges();
        }
    }

    public Cart GetCartByUserUserName(string username)
    {
        return context.Carts.Where(c => c.User.Username == username).FirstOrDefault();
    }
}