using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository userRepository;
        public UserController()
        {
            this.userRepository = new UserSQL_CRUD();
        }
        [HttpGet]
        public IHttpActionResult GetAll_Users()
        {
            var data = userRepository.GetAllUsers();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_User(int id)
        {
            var data = userRepository.GetUser(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Add_User(User user)
        {
            var data = userRepository.AddUser(user);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Update_User(User user)
        {
            var data = userRepository.UpdateUser(user);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_User(int id)
        {
            var data = userRepository.DeleteUser(id);
            return Ok(data);
        }
    }
}
