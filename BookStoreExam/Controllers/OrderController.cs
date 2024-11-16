using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public OrderController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public Order GetOrder(int Id)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == Id);
            return order;
        }


        [HttpGet]
        public List<Order> GetOrder()
        {
            var order = _context.Order.ToList();
            return order;
        }


        [HttpPost]
        public int PostOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
            return order.Id;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, Order order)
        {
            var existingA = _context.Order.FirstOrDefault(a => a.Id == id);
            if (existingA == null)
            {
                return NotFound();
            }

            existingA.Coment = order.Coment;
           


            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public void DeleteOreder([FromBody] Order order)
        {
            var updA = _context.Order.FirstOrDefault(a => a.Coment == order.Coment);

            if (updA != null)
            {
                _context.Order.Remove(updA);
                _context.SaveChanges();
            }
           
        }

    }
}
