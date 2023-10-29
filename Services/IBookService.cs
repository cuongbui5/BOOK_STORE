using BOOK_STORE_DEMO.Dtos.Response;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Repository;

namespace BOOK_STORE_DEMO.Services
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAllBooks();
        public BookResponse GetBookByFilter(int? category, int page,string searchStr);

        public Book GetBookById(int bookId);

        public void AddBook(Book book);

        public void UpdateBook( Book book);

        public void DeleteBook(int bookId);
    }
}
