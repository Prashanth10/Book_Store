using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStore.Models.Admin;

namespace BookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AdminController : ApiController
    {
        private IAdminRepository adminRepository;
        public AdminController()
        {
            this.adminRepository = new Admin_CRUD();
        }
        [HttpPost]
        [Route("api/admin/auth")]
        public IHttpActionResult Authenticate(Admin admin)
        {
            var data = adminRepository.Auth(admin);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetAll_Admins()
        {
            var data = adminRepository.GetAllAdmins();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Admin(int id)
        {
            var data = adminRepository.GetAdmin(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Add_Admin(Admin admin)
        {
            var data = adminRepository.AddAdmin(admin);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Update_Admin(Admin admin)
        {
            var data = adminRepository.UpdateAdmin(admin);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_Admin(int id)
        {
            var data = adminRepository.DeleteAdmin(id);
            return Ok(data);
        }
    }
}
