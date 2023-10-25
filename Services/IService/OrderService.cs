using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Repositories;

namespace BOOK_STORE_DEMO.Services.IService;

public class OrderService:IOrderService
{
    private readonly IOrderRepository orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }
    public Order CreateOrder(Order order)
    {
        return orderRepository.CreateOrder(order);
    }
}