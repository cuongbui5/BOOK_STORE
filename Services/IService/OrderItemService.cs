﻿using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Repositories;

namespace BOOK_STORE_DEMO.Services.IService;

public class OrderItemService:IOrderItemService
{
    private readonly IOrderItemRepository orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        this.orderItemRepository = orderItemRepository;
    }

    public OrderItem CreateOrderItem(OrderItem orderItem)
    {
        return orderItemRepository.CreateOrderItem(orderItem);
    }
}