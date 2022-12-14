using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStore.Models.Category;

namespace BookStore.Controllers
{
    [EnableCors(origins:"http://localhost:4200",headers:"*",methods:"*")]
    public class CategoryController : ApiController
    {
        private ICategoryRepository categoryRepository;
        public CategoryController()
        {
            this.categoryRepository = new Category_CRUD();
        }
        [HttpGet]
        public IHttpActionResult GetAll_Category()
        {
            var data = categoryRepository.GetAllCategory();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Category(int id)
        {
            var data = categoryRepository.GetCategory(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Add_Category(Category cat)
        {
            var data = categoryRepository.AddCategory(cat);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Update_Category(Category cat)
        {
            var data = categoryRepository.UpdateCategory(cat);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_Category(int id)
        {
            var data = categoryRepository.DeleteCategory(id);
            return Ok(data);
        }
    }
}
