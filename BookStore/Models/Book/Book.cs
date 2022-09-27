using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Book
{
    public class Book
    {
        public int Id { get; set; }
        public int Cat_id { get; set; }
        public string Title { get; set; }
        public long ISBN { get; set; }
        public DateTime Year { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }

        public Book()
        {

        }
        public Book(int id, int cat_id, string title, long isbn, DateTime year, int price, string description, int position, bool status, string image)
        {
            Id = id;
            Cat_id = cat_id;
            Title = title;
            ISBN = isbn;
            Year = year;
            Price = price;
            Description = description;
            Position = position;
            Status = status;
            Image = image;
        }
    }
}