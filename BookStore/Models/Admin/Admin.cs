using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Admin
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }

        public Admin()
        {

        }
        public Admin(int id, string name, string email, long phone, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}