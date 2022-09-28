using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Category
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public int Position { get; set; }
        public DateTime CreatedAt { get; set; }

        public Category()
        {

        }
        public Category(int id, string name, string description, string image, bool status, int position)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Status = status;
            Position = position;
        }
        public Category(int id, string name, string description, string image, bool status, int position, DateTime createdat)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Status = status;
            Position = position;
            CreatedAt = createdat;
        }
    }
}