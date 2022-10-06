using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStore.Models.Order;

namespace BookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        private IOrderRepository orderRepository;
        public OrderController()
        {
            this.orderRepository = new Order_CRUD();
        }
        [HttpGet]
        [Route("api/order")]
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

        [HttpGet]
        [Route("api/order/")]
        public IHttpActionResult GetAll_Order_ByUserId(int userId)
        {
            var data = orderRepository.GetAllOrder_ByUserId(userId);
            return Ok(data);
        }

        [HttpPut]
        [Route("api/order/")]
        public IHttpActionResult Add_Order(Order order)
        {
            var data = orderRepository.AddOrder(order);
            return Ok(data);
        }

        [HttpPost]
        [Route("api/order/")]
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
