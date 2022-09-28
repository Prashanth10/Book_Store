using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Admin
{
    public interface IAdminRepository
    {
        bool Auth(Admin admin);
        List<Admin> GetAllAdmins();
        Admin GetAdmin(int id);
        bool AddAdmin(Admin admin);
        bool UpdateAdmin(Admin admin);
        bool DeleteAdmin(int id);
    }
}