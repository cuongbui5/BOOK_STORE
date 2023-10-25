using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repositories;

public interface IOrderRepository
{
    Order CreateOrder(Order order);
}