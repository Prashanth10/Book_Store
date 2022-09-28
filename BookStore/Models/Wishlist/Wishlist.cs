using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Wishlist
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Book_id { get; set; }

        public Wishlist()
        {

        }
        public Wishlist(int id, int user_id, int book_id)
        {
            Id = id;
            User_id = user_id;
            Book_id = book_id;
        }
    }
}