using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Order
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrder();
        Order GetOrder(int id);
        bool AddOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int id);
    }
}