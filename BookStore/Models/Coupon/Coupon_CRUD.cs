using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Models.Coupon
{
    public class Coupon_CRUD : ICouponRepository
    {
        private SqlConnection conn;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        public bool AddCoupon(Coupon coupon)       //http://localhost:63709/api/coupon (httpput)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into coupon (admin_id, coupon_code, coupon_discount) " +
                "values (" + coupon.Admin_Id + ",'" + coupon.Code + "'," + coupon.Discount + ")";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public bool DeleteCoupon(int id)      //http://localhost:63709/api/coupon/3 (httpdelete)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from coupon where coupon_id=" + id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0 ? true : false;
        }

        public Coupon GetCoupon(int id)        //http://localhost:63709/api/coupon/1 (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from coupon where coupon_id=" + id;
            SqlDataReader dr = comm.ExecuteReader();
            Coupon coupon = new Coupon();
            if (dr.Read())
            {
                coupon.Id = dr.GetInt32(0);
                coupon.Admin_Id = dr.GetInt32(0);
                coupon.Code = dr.GetString(2);
                coupon.Discount = dr.GetInt32(3);
            }
            conn.Close();
            return coupon;
        }

        public List<Coupon> GetAllCoupons()        //http://localhost:63709/api/coupon (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from coupon";
            SqlDataReader dr = comm.ExecuteReader();
            List<Coupon> coupons = new List<Coupon>();
            while (dr.Read())
            {
                Coupon coupon = new Coupon();
                coupon.Id = dr.GetInt32(0);
                coupon.Admin_Id = dr.GetInt32(0);
                coupon.Code = dr.GetString(2);
                coupon.Discount = dr.GetInt32(3);
                coupons.Add(coupon);
            }
            conn.Close();
            return coupons;
        }

        public bool UpdateCoupon(Coupon coupon)         //http://localhost:63709/api/coupon (httppost)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "update coupon set admin_id="+coupon.Admin_Id+", coupon_code='"+coupon.Code+"', " +
                "coupon_discount="+coupon.Discount+" where coupon_id=" + coupon.Id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }
    }
}