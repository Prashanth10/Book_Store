using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Book_id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Savings { get; set; }
        public DateTime Order_date { get; set; }

        public Order()
        {

        }
        public Order(int id, int user_id, int book_id, int price, int savings)
        {
            Id = id;
            User_id = user_id;
            Book_id = book_id;
            Price = price;
            Savings = savings;
        }
        public Order(int id, int user_id, int book_id, int price, int savings, DateTime order_date)
        {
            Id = id;
            User_id = user_id;
            Book_id = book_id;
            Price = price;
            Savings = savings;
            Order_date = order_date;
        }
    }
}