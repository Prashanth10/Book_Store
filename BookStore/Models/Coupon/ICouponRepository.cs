using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Coupon
{
    public interface ICouponRepository
    {
        List<Coupon> GetAllCoupons();
        Coupon GetCoupon(int id);
        bool AddCoupon(Coupon coupon);
        bool UpdateCoupon(Coupon coupon);
        bool DeleteCoupon(int id);
    }
}