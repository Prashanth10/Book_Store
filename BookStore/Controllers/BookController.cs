using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models.Book;

namespace BookStore.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository bookRepository;
        public BookController()
        {
            this.bookRepository = new Book_CRUD();
        }
        [HttpGet]
        public IHttpActionResult GetAll_Category()
        {
            var data = bookRepository.GetAllBook();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Category(int id)
        {
            var data = bookRepository.GetBook(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Add_Category(Book bk)
        {
            var data = bookRepository.AddBook(bk);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Update_Category(Book bk)
        {
            var data = bookRepository.UpdateBook(bk);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_Category(int id)
        {
            var data = bookRepository.DeleteBook(id);
            return Ok(data);
        }
    }
}
