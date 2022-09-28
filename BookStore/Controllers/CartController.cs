using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models.Cart;

namespace BookStore.Controllers
{
    public class CartController : ApiController
    {
        private ICartRepository cartRepository;
        public CartController()
        {
            this.cartRepository = new Cart_CRUD();
        }
        [HttpGet]
        public IHttpActionResult GetAll_Carts()
        {
            var data = cartRepository.GetAllCarts();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Cart(int id)
        {
            var data = cartRepository.GetCart(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Add_Cart(Cart cart)
        {
            var data = cartRepository.AddCart(cart);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Update_Cart(Cart cart)
        {
            var data = cartRepository.UpdateCart(cart);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_Cart(int id)
        {
            var data = cartRepository.DeleteCart(id);
            return Ok(data);
        }
    }
}
