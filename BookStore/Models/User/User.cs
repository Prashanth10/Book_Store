using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public User()
        {
            
        }
        public User(int id, string name, string email, DateTime dob, string gender, long phone, string password, bool active)
        {
            Id = id;
            Name = name;
            Email = email;
            DOB = dob;
            Gender = gender;
            Phone = phone;
            Password = password;
            Active = active;
        }
    }
}