using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Coupon
{
    public class Coupon
    {
        public int Id { get; set; }
        public int Admin_Id { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }

        public Coupon()
        {

        }
        public Coupon(int id, int admin_id, string code, int discount)
        {
            Id = id;
            Admin_Id = admin_id;
            Code = code;
            Discount = discount;
        }
    }
}