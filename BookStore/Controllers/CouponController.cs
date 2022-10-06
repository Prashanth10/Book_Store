using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStore.Models.Coupon;

namespace BookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CouponController : ApiController
    {
        private ICouponRepository couponRepository;
        public CouponController()
        {
            this.couponRepository = new Coupon_CRUD();
        }
        [HttpGet]
        public IHttpActionResult GetAll_Coupons()
        {
            var data = couponRepository.GetAllCoupons();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Coupon(int id)
        {
            var data = couponRepository.GetCoupon(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Add_Coupon(Coupon coupon)
        {
            var data = couponRepository.AddCoupon(coupon);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Update_Coupon(Coupon coupon)
        {
            var data = couponRepository.UpdateCoupon(coupon);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_Coupon(int id)
        {
            var data = couponRepository.DeleteCoupon(id);
            return Ok(data);
        }
    }
}
