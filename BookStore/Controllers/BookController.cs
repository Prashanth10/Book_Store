using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStore.Models.Book;

namespace BookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class BookController : ApiController
    {
        private IBookRepository bookRepository;
        public BookController()
        {
            this.bookRepository = new Book_CRUD();
        }
        [HttpGet]
        [Route("api/book/")]
        public IHttpActionResult GetAll_Book()
        {
            var data = bookRepository.GetAllBook();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Book(int id)
        {
            var data = bookRepository.GetBook(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
        [HttpGet]
        [Route("api/book/")]
        public IHttpActionResult GetAll_Book_ByCategory(string by, string query)
        {
            var data = bookRepository.GetAllBook_ByQuery(by,query);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        [Route("api/book/")]
        public IHttpActionResult Add_Book(Book bk)
        {
            var data = bookRepository.AddBook(bk);
            return Ok(data);
        }

        [HttpPost]
        [Route("api/book/")]
        public IHttpActionResult Update_Book(Book bk)
        {
            var data = bookRepository.UpdateBook(bk);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_Book(int id)
        {
            var data = bookRepository.DeleteBook(id);
            return Ok(data);
        }
    }
}
