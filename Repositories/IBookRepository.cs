﻿using BOOK_STORE_DEMO.Dtos.Response;
using BOOK_STORE_DEMO.Models;

namespace BOOK_STORE_DEMO.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        BookResponse GetBookByPageAndCategory(int?categoryId,int page);


        Book GetBookById(int bookId);


        void AddBook(Book book);


        void UpdateBook(Book book);

        void DeleteBook(int bookId);
    }
}