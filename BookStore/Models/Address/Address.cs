using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Address
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Adrs { get; set; }

        public Address()
        {

        }
        public Address(int id, int userId, string adrs)
        {
            Id = id;
            UserId = userId;
            Adrs = adrs;
        }
    }
}