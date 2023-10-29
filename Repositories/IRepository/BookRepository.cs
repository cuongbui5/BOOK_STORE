using BOOK_STORE_DEMO.Data;
using BOOK_STORE_DEMO.Dtos.Response;
using BOOK_STORE_DEMO.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;
using BOOK_STORE_DEMO.Util;

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

        public BookResponse GetBookByFilter(int? categoryId, int page,string searchStr)
        {
            IEnumerable<Book> books=new List<Book>();
            BookResponse bookResponse = new BookResponse();
            
            if (searchStr != "")
            {
                books= context.Books.Where(b=>b.Name.Contains(searchStr)).ToList();
                bookResponse.CurrentPage = page;
                bookResponse.TotalPages = (books.Count()+Constant.PAGE_SIZE-1)/Constant.PAGE_SIZE;
                bookResponse.Books = books.ToPagedList(page, Constant.PAGE_SIZE);
            
                return bookResponse;
            }
            
            if (categoryId == null||categoryId==0)
            {
                 books= context.Books.ToList();
                 
            }
            else
            {
                books=context.Books.Where(b=>b.CategoryId==categoryId);
                bookResponse.CategoryId = categoryId.Value;
            }

         
            
            
            

            
            bookResponse.CurrentPage = page;
            bookResponse.TotalPages = (books.Count()+Constant.PAGE_SIZE-1)/Constant.PAGE_SIZE;
            bookResponse.Books = books.ToPagedList(page, Constant.PAGE_SIZE);
            
            return bookResponse;


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
