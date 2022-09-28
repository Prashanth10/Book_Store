using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Order
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrder();
        List<Order> GetAllOrder_ByUserId(int userId);
        Order GetOrder(int id);
        bool AddOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int id);
    }
}