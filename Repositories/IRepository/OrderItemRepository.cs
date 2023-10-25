using BOOK_STORE_DEMO.Data;
using BOOK_STORE_DEMO.Models;

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
}