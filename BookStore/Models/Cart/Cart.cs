using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Cart
{
    public class Cart
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Book_id { get; set; }

        public Cart()
        {

        }
        public Cart(int id, int user_id, int book_id)
        {
            Id = id;
            User_id = user_id;
            Book_id = book_id;
        }
    }
}