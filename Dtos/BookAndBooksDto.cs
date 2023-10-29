using BOOK_STORE_DEMO.Models;
namespace BOOK_STORE_DEMO.Dtos
{
    public class BookAndBooksDto
    {
        public Book Book { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
