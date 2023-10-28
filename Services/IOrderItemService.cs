using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Services;

public interface IOrderItemService
{
    OrderItem CreateOrderItem(OrderItem orderItem);
    IEnumerable<OrderItem> GetOrderItemsByOrderID(int orderID);

    void deleteByOrderID(int orderID);
}