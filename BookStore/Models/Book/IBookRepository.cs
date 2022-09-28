using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Book
{
    public interface IBookRepository
    {
        List<Book> GetAllBook();
        List<Book> GetAllBook_ByCatId(int catId);
        Book GetBook(int id);
        bool AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}