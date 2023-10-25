using BOOK_STORE_DEMO.Data;
using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repositories.IRepository;

public class OrderRepository:IOrderRepository
{
    private readonly BookStoreDBContext context;

    public OrderRepository(BookStoreDBContext context)
    {
        this.context = context;
    }

    public Order CreateOrder(Order order)
    {
        var entityEntry = context.Orders.Add(order);
        context.SaveChanges();
    
        
        Order newOrder = entityEntry.Entity;

        return newOrder;
    }
}