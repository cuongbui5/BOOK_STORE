using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repositories;

public interface IOrderRepository
{
    Order CreateOrder(Order order);
    IEnumerable<Order> getAllOrders();

    void deleteByOrderID(int orderID);
}