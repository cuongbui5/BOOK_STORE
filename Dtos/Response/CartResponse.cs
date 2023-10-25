using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Dtos.Response;

public class CartResponse
{
    public int Id { get; set; }
    public IEnumerable<CartItem> CartItems { get; set; }
    public decimal Total { get; set; }
}