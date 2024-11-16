using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public OrderDetailsController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDetails>> GetOrderDetails()
        {
            var orderDetails = _context.OrderDetails.ToList();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDetails> GetOrderDetail(int id)
        {
            var orderDetail = _context.OrderDetails.FirstOrDefault(od => od.Id == id);
            if (orderDetail == null)
            {
                return NotFound($"OrderDetail with Id {id} not found.");
            }
            return Ok(orderDetail);
        }

        [HttpPost]
        public ActionResult<int> PostOrderDetail(OrderDetails orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetail.Id }, orderDetail.Id);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderDetail(int id, OrderDetails orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return BadRequest("OrderDetail ID mismatch.");
            }

            var existingOrderDetail = _context.OrderDetails.FirstOrDefault(od => od.Id == id);
            if (existingOrderDetail == null)
            {
                return NotFound($"OrderDetail with Id {id} not found.");
            }

            existingOrderDetail.Bookcount = orderDetail.Bookcount;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrderDetail(int id)
        {
            var orderDetail = _context.OrderDetails.FirstOrDefault(od => od.Id == id);
            if (orderDetail == null)
            {
                return NotFound($"OrderDetail with Id {id} not found.");
            }

            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
