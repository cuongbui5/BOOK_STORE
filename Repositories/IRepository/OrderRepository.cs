using BOOK_STORE_DEMO.Data;
using BOOK_STORE_DEMO.Models;
using Microsoft.EntityFrameworkCore;

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

    public IEnumerable<Order> getAllOrders()
    {
        return context.Orders.Include(o=>o.User).Include(o=>o.OrderItems).ToList();
    }

    public void deleteByOrderID(int orderID)
    { 
        var recordToDetele=context.Orders.FirstOrDefault(o=>o.Id==orderID);
        context.Orders.Remove(recordToDetele);
        context.SaveChanges();
    }
}