﻿using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repositories.IRepository;

public interface ICartItemRepository
{
    CartItem CreateCartItem(CartItem cartItem);
    void UpdateCartItem(CartItem cartItem);
    List<CartItem> GetCartItemsByCartId(int cartId);
    void DeleteCartItemByCartId(int cartId);
    CartItem GetCartItemById(int id);
    void DeleteCartItemById(int id);


}