using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models.Address;

namespace BookStore.Controllers
{
    public class AddressController : ApiController
    {
        private IAddressRepository addressRepository;
        public AddressController()
        {
            this.addressRepository = new Address_CRUD();
        }
        
        [HttpGet]
        public IHttpActionResult GetAll_Addresss()
        {
            var data = addressRepository.GetAllAddresss();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Address(int id)
        {
            var data = addressRepository.GetAddress(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Address_ByUserId(int userId)
        {
            var data = addressRepository.GetAllAddresss_ByUserId(userId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Add_Address(Address address)
        {
            var data = addressRepository.AddAddress(address);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Update_Address(Address address)
        {
            var data = addressRepository.UpdateAddress(address);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_Address(int id)
        {
            var data = addressRepository.DeleteAddress(id);
            return Ok(data);
        }
    }
}
