using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Models.Book
{
    public class Book_CRUD : IBookRepository
    {
        private SqlConnection conn;
        public void Connection()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionstring);
        }

        public bool AddBook(Book book)        //http://localhost:63709/api/book (httpput)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into book (cat_id,bk_title,bk_isbn,bk_year,bk_price,bk_description,bk_position,bk_image) " +
                "values("+book.Cat_id+", '"+book.Title+"', "+book.ISBN+", '"+book.Year+"', "+book.Price+", '"+book.Description+"', "+book.Position+", '"+book.Image+"')";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public bool DeleteBook(int id)        //http://localhost:63709/api/book/5 (httpdelete)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from book where bk_id=" + id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public List<Book> GetAllBook()        //http://localhost:63709/api/book (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from book";
            SqlDataReader dr = comm.ExecuteReader();
            List<Book> books = new List<Book>();
            while (dr.Read())
            {
                Book book = new Book();
                book.Id = dr.GetInt32(0);
                book.Cat_id = dr.GetInt32(1);
                book.Title = dr.GetString(2);
                book.ISBN = dr.GetInt64(3);
                book.Year = dr.GetDateTime(4);
                book.Price = dr.GetInt32(5);
                book.Description = dr.GetString(6);
                book.Position = dr.GetInt32(7);
                book.Status = dr.GetBoolean(8);
                book.Image = dr.GetString(9);
                books.Add(book);
            }
            conn.Close();
            return books;
        }

        public List<Book> GetAllBook_ByQuery(string by, string query)        
        {
            /*    http://localhost:63709/api/book?by=name&query=%om% (httpget)
                http://localhost:63709/api/book?by=catId&query=1
                http://localhost:63709/api/book?by=isbn&query=9354600433*/
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            switch (by)
            {
                case "name":
                    comm.CommandText = "select * from book where bk_title like '"+query+"' ";
                    break;
                case "catId":
                    int catid = Convert.ToInt32(query);
                    comm.CommandText = "select * from book where cat_id=" + catid;
                    break;
                case "isbn":
                    long isbn = Convert.ToInt64(query);
                    comm.CommandText = "select * from book where bk_isbn=" + isbn;
                    break;
                default:
                    return null;
                    break;
            }
            
            SqlDataReader dr = comm.ExecuteReader();
            List<Book> books = new List<Book>();
            while (dr.Read())
            {
                Book book = new Book();
                book.Id = dr.GetInt32(0);
                book.Cat_id = dr.GetInt32(1);
                book.Title = dr.GetString(2);
                book.ISBN = dr.GetInt64(3);
                book.Year = dr.GetDateTime(4);
                book.Price = dr.GetInt32(5);
                book.Description = dr.GetString(6);
                book.Position = dr.GetInt32(7);
                book.Status = dr.GetBoolean(8);
                book.Image = dr.GetString(9);
                books.Add(book);
            }
            conn.Close();
            return books;
        }

        public Book GetBook(int id)       //http://localhost:63709/api/book/3 (Httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from book where bk_id=" + id;
            SqlDataReader dr = comm.ExecuteReader();
            Book book = new Book();
            if (dr.Read())
            {
                book.Id = dr.GetInt32(0);
                book.Cat_id = dr.GetInt32(1);
                book.Title = dr.GetString(2);
                book.ISBN = dr.GetInt64(3);
                book.Year = dr.GetDateTime(4);
                book.Price = dr.GetInt32(5);
                book.Description = dr.GetString(6);
                book.Position = dr.GetInt32(7);
                book.Status = dr.GetBoolean(8);
                book.Image = dr.GetString(9);
            }
            conn.Close();
            return book;
        }

        public bool UpdateBook(Book book)       //http://localhost:63709/api/book (httppost)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            int status = Convert.ToInt32(book.Status);
            comm.CommandText = "update book set cat_id="+book.Cat_id+", bk_title='"+ book.Title+"', bk_isbn="+book.ISBN+", bk_year='"+book.Year+"', " +
                "bk_price="+book.Price+", bk_description='"+book.Description+ "', bk_position="+book.Position+", " +
                "bk_status="+status+ ", bk_image='"+book.Image+"' where bk_id="+ book.Id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }
    }
}