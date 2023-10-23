using BOOK_STORE_DEMO.Data;
using BOOK_STORE_DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace BOOK_STORE_DEMO.Repository.impl
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDBContext context;
        public BookRepository(BookStoreDBContext context) {
            this.context = context;
        }
        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            Book b=context.Books.Find(bookId);
            if (b != null)
            {
                context.Books.Remove(b);
                context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books.Include(b=>b.Category).ToList();
        }

        public Book GetBookById(int bookId)
        {
            return context.Books.Include(b=>b.Category).Where(b=>b.Id==bookId).FirstOrDefault();
        }

        public void UpdateBook(Book book)
        {
            context.Books.Update(book);
            context.SaveChanges();  
        }
    }
}
