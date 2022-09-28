using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.User
{
    public interface IUserRepository
    {
        bool Auth(User user);
        List<User> GetAllUsers();
        User GetUser(int id);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        bool ActivateUser(int id, bool status);
    }
}