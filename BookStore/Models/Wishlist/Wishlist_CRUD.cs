using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Models.Wishlist
{
    public class Wishlist_CRUD : IWishlistRepository
    {
        private SqlConnection conn;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        public bool AddWishlist(Wishlist wishlist)       //http://localhost:63709/api/wishlist (httpput)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into wishlist (user_id, bk_id) " +
                "values (" + wishlist.User_id + "," + wishlist.Book_id + ")";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public bool DeleteWishlist(int id)      //http://localhost:63709/api/wishlist/3 (httpdelete)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from wishlist where wish_id=" + id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0 ? true : false;
        }

        public Wishlist GetWishlist(int id)        //http://localhost:63709/api/wishlist/1 (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from wishlist where wish_id=" + id;
            SqlDataReader dr = comm.ExecuteReader();
            Wishlist wishlist = new Wishlist();
            if (dr.Read())
            {
                wishlist.Id = dr.GetInt32(0);
                wishlist.User_id = dr.GetInt32(1);
                wishlist.Book_id = dr.GetInt32(2);
            }
            conn.Close();
            return wishlist;
        }

        public List<Wishlist> GetAllWishlists()        //http://localhost:63709/api/wishlist (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [wishlist]";
            SqlDataReader dr = comm.ExecuteReader();
            List<Wishlist> wishlists = new List<Wishlist>();
            while (dr.Read())
            {
                Wishlist wishlist = new Wishlist();
                wishlist.Id = dr.GetInt32(0);
                wishlist.User_id = dr.GetInt32(1);
                wishlist.Book_id = dr.GetInt32(2);
                wishlists.Add(wishlist);
            }
            conn.Close();
            return wishlists;
        }

        public bool UpdateWishlist(Wishlist wishlist)         //http://localhost:63709/api/wishlist (httppost)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "update wishlist set user_id="+wishlist.User_id+", bk_id="+wishlist.Book_id+" where wish_id=" + wishlist.Id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }
    }
}