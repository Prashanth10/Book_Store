using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Book
{
    public interface IBookRepository
    {
        List<Book> GetAllBook();
        Book GetBook(int id);
        bool AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}