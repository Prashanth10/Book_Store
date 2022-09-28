using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Book_id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Savings { get; set; }
        public string Address { get; set; }
        public DateTime Order_date { get; set; }

        public Order()
        {

        }
        public Order(int id, int user_id, int book_id, int price, int savings, string addresss)
        {
            Id = id;
            User_id = user_id;
            Book_id = book_id;
            Price = price;
            Savings = savings;
            Address = addresss;
        }
        public Order(int id, int user_id, int book_id, int price, int savings, string addresss, DateTime order_date)
        {
            Id = id;
            User_id = user_id;
            Book_id = book_id;
            Price = price;
            Savings = savings;
            Address = addresss;
            Order_date = order_date;
        }
    }
}