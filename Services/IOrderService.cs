﻿using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Services;

public interface IOrderService
{
    Order CreateOrder(Order order);
    IEnumerable<Order> getAllOrders();

    void deleteByOrderID(int orderID);
}