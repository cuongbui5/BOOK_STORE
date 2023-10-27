using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repositories;

public interface IOrderItemRepository
{
    OrderItem CreateOrderItem(OrderItem orderItem);
    IEnumerable<OrderItem> GetOrderItemsByOrderID(int orderID);

    void deleteByOrderID(int orderID);
}