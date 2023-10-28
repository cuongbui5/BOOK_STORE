using BOOK_STORE_DEMO.Data;
using BOOK_STORE_DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace BOOK_STORE_DEMO.Repositories.IRepository;

public class OrderItemRepository:IOrderItemRepository
{
    private readonly BookStoreDBContext context;

    public OrderItemRepository(BookStoreDBContext context)
    {
        this.context = context;
    }
    public OrderItem CreateOrderItem(OrderItem orderItem)
    {
        
        var entityEntry = context.OrderItems.Add(orderItem);
        context.SaveChanges();
        OrderItem newOrderItem = entityEntry.Entity;
        return newOrderItem;
    }

    public IEnumerable<OrderItem> GetOrderItemsByOrderID(int orderID)
    {
        return context.OrderItems.Include(oi=>oi.Book).Where(oi=>oi.OrderId==orderID).ToList();
    }

    public void deleteByOrderID(int orderID)
    {
        var recordsToDelete = context.OrderItems.Where(ot => ot.OrderId == orderID).ToList();
        context.OrderItems.RemoveRange(recordsToDelete);
        context.SaveChanges();
    }
}