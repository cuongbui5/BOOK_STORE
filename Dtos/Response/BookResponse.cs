using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Dtos.Response;

public class BookResponse
{
    public IEnumerable<Book> Books { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int CategoryId { get; set; }
}