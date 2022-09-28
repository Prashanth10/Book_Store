using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models.Wishlist;

namespace BookStore.Controllers
{
    public class WishlistController : ApiController
    {
        private IWishlistRepository wishlistRepository;
        public WishlistController()
        {
            this.wishlistRepository = new Wishlist_CRUD();
        }
        [HttpGet]
        public IHttpActionResult GetAll_Wishlists()
        {
            var data = wishlistRepository.GetAllWishlists();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Wishlist(int id)
        {
            var data = wishlistRepository.GetWishlist(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Add_Wishlist(Wishlist wishlist)
        {
            var data = wishlistRepository.AddWishlist(wishlist);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Update_Wishlist(Wishlist wishlist)
        {
            var data = wishlistRepository.UpdateWishlist(wishlist);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_Wishlist(int id)
        {
            var data = wishlistRepository.DeleteWishlist(id);
            return Ok(data);
        }
    }
}
