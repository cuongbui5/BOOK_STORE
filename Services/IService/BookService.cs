using BOOK_STORE_DEMO.Dtos.Response;
using BOOK_STORE_DEMO.Models;
using BOOK_STORE_DEMO.Repository;

namespace BOOK_STORE_DEMO.Services.impl
{
    public class BookService:IBookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository) {
            this.bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            bookRepository.AddBook(book);
        }

        public void DeleteBook(int bookId)
        {
           bookRepository.DeleteBook(bookId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
           return bookRepository.GetAllBooks();
        }

        public Book GetBookById(int bookId)
        {
            return bookRepository.GetBookById(bookId);
        }

        public void UpdateBook(Book book)
        {
           bookRepository.UpdateBook(book);
        }

        public BookResponse GetBookByFilter(int? category, int page,string searchStr)
        {
            return bookRepository.GetBookByFilter(category,page, searchStr);
        }
    }
}
