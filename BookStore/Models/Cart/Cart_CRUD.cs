using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Models.Cart
{
    public class Cart_CRUD : ICartRepository
    {
        private SqlConnection conn;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        public bool AddCart(Cart cart)       //http://localhost:63709/api/cart (httpput)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into cart (user_id, bk_id) " +
                "values (" + cart.User_id + "," + cart.Book_id + ")";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public bool DeleteCart(int id)      //http://localhost:63709/api/cart/3 (httpdelete)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from cart where cart_id=" + id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0 ? true : false;
        }

        public Cart GetCart(int id)        //http://localhost:63709/api/cart/1 (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from cart where cart_id=" + id;
            SqlDataReader dr = comm.ExecuteReader();
            Cart cart = new Cart();
            if (dr.Read())
            {
                cart.Id = dr.GetInt32(0);
                cart.User_id = dr.GetInt32(1);
                cart.Book_id = dr.GetInt32(2);
            }
            conn.Close();
            return cart;
        }

        public List<Cart> GetAllCarts()        //http://localhost:63709/api/cart (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from cart";
            SqlDataReader dr = comm.ExecuteReader();
            List<Cart> carts = new List<Cart>();
            while (dr.Read())
            {
                Cart cart = new Cart();
                cart.Id = dr.GetInt32(0);
                cart.User_id = dr.GetInt32(1);
                cart.Book_id = dr.GetInt32(2);
                carts.Add(cart);
            }
            conn.Close();
            return carts;
        }

        public bool UpdateCart(Cart cart)         //http://localhost:63709/api/cart (httppost)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "update cart set user_id=" + cart.User_id + ", bk_id=" + cart.Book_id + " where cart_id=" + cart.Id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }
    }
}