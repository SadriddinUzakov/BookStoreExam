using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public OrderController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            var orders = _context.Order.ToList();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound($"Order with Id {id} not found.");
            }
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<int> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Order.Add(order);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order.Id);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest("Order ID mismatch.");
            }

            var existingOrder = _context.Order.FirstOrDefault(o => o.Id == id);
            if (existingOrder == null)
            {
                return NotFound($"Order with Id {id} not found.");
            }

            existingOrder.Comment = order.Comment;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound($"Order with Id {id} not found.");
            }

            _context.Order.Remove(order);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
