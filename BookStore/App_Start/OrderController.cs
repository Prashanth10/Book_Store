using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models.Order;

namespace BookStore.Controllers
{
    public class OrderController : ApiController
    {
        private IOrderRepository orderRepository;
        public OrderController()
        {
            this.orderRepository = new Order_CRUD();
        }
        [HttpGet]
        public IHttpActionResult GetAll_Order()
        {
            var data = orderRepository.GetAllOrder();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get_Order(int id)
        {
            var data = orderRepository.GetOrder(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Add_Order(Order order)
        {
            var data = orderRepository.AddOrder(order);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Update_Order(Order order)
        {
            var data = orderRepository.UpdateOrder(order);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete_Order(int id)
        {
            var data = orderRepository.DeleteOrder(id);
            return Ok(data);
        }
    }
}
