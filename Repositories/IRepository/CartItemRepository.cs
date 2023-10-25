using BOOK_STORE_DEMO.Data;
using BOOK_STORE_DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace BOOK_STORE_DEMO.Repositories.IRepository;

public class CartItemRepository:ICartItemRepository
{
    private readonly BookStoreDBContext context;
    public CartItemRepository(BookStoreDBContext context)
    {
        this.context = context;
    }
    public CartItem CreateCartItem(CartItem cartItem)
    {
        var entityEntry = context.CartItems.Add(cartItem);
        context.SaveChanges();
    
        
        CartItem newCartItem = entityEntry.Entity;

        return newCartItem;
    }

    public void UpdateCartItem(CartItem cartItem)
    {
        context.CartItems.Update(cartItem);
        context.SaveChanges();


    }

    public List<CartItem> GetCartItemsByCartId(int cartId)
    {
        return context.CartItems.Where(c => c.CartId == cartId).Include(c=>c.Book).ToList();
    }

    public void DeleteCartItemByCartId(int cartId)
    {
        List<CartItem> cartItems = context.CartItems.Where(c => c.CartId == cartId).ToList();
        foreach (var cartItem in cartItems)
        {
            context.CartItems.Remove(cartItem);
        }

        context.SaveChanges();
    }

    public CartItem GetCartItemById(int id)
    {
        return context.CartItems.Find(id);
    }

    public void DeleteCartItemById(int id)
    {
        CartItem cartItem = context.CartItems.Find(id);
        if (cartItem != null)
        {
            context.CartItems.Remove(cartItem);
            context.SaveChanges();
        }
        
    }
}