using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Address
{
    public interface IAddressRepository
    {
        List<Address> GetAllAddresss();
        List<Address> GetAllAddresss_ByUserId(int userId);
        Address GetAddress(int id);
        bool AddAddress(Address address);
        bool UpdateAddress(Address address);
        bool DeleteAddress(int id);
    }
}