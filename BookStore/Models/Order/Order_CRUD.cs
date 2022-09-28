using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models.Order
{
    public class Order_CRUD : IOrderRepository
    {
        private SqlConnection conn;
        public void Connection()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            conn = new SqlConnection(connectionstring);
        }
        public bool AddOrder(Order order)      //http://localhost:63709/api/order (httpput)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into [order] (user_id,bk_id,price,quantity,savings,[address]) " +
                "values(" + order.User_id + "," + order.Book_id + "," + order.Price + "," + order.Quantity + "," + order.Savings + ",'"+order.Address+"')";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public bool DeleteOrder(int id)      //http://localhost:63709/api/order/1 (httpdelete)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from [order] where order_id=" + id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }

        public List<Order> GetAllOrder()      //http://localhost:63709/api/order (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [order]";
            SqlDataReader dr = comm.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (dr.Read())
            {
                Order order = new Order();
                order.Id = dr.GetInt32(0);
                order.User_id = dr.GetInt32(1);
                order.Book_id = dr.GetInt32(2);
                order.Price = dr.GetInt32(3);
                order.Quantity = dr.GetInt32(4);
                order.Savings = dr.GetInt32(5);
                order.Address = dr.GetString(6);
                order.Order_date = dr.GetDateTime(7);
                orders.Add(order);
            }
            conn.Close();
            return orders;
        }

        public List<Order> GetAllOrder_ByUserId(int userID)      //http://localhost:63709/api/order?userId=1 (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [order] where user_id="+userID;
            SqlDataReader dr = comm.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (dr.Read())
            {
                Order order = new Order();
                order.Id = dr.GetInt32(0);
                order.User_id = dr.GetInt32(1);
                order.Book_id = dr.GetInt32(2);
                order.Price = dr.GetInt32(3);
                order.Quantity = dr.GetInt32(4);
                order.Savings = dr.GetInt32(5);
                order.Address = dr.GetString(6);
                order.Order_date = dr.GetDateTime(7);
                orders.Add(order);
            }
            conn.Close();
            return orders;
        }

        public Order GetOrder(int id)     //http://localhost:63709/api/order/1 (httpget)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [order] where order_id=" + id;
            SqlDataReader dr = comm.ExecuteReader();
            Order order = new Order();
            if (dr.Read())
            {
                order.Id = dr.GetInt32(0);
                order.User_id = dr.GetInt32(1);
                order.Book_id = dr.GetInt32(2);
                order.Price = dr.GetInt32(3);
                order.Quantity = dr.GetInt32(4);
                order.Savings = dr.GetInt32(5);
                order.Address = dr.GetString(6);
                order.Order_date = dr.GetDateTime(7);
            }
            conn.Close();
            return order;
        }

        public bool UpdateOrder(Order order)       //http://localhost:63709/api/order/ (httppost)
        {
            Connection();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "update [order] set user_id="+order.User_id+", bk_id="+order.Book_id+", quantity="+order.Quantity+", " +
                "savings="+order.Savings+", [address]='"+order.Address+"' where order_id=" + order.Id;
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row > 0;
        }
    }
}