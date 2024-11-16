using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly BookStoreContext _context;
        public OrderDetailsController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public OrderDetails GetOrderD(int Id)
        {
            var order = _context.OrderD.FirstOrDefault(o => o.Id == Id);
            return order;
        }


        [HttpGet]
        public List<OrderDetails> GetOrderD()
        {
            var order = _context.OrderD.ToList();
            return order;
        }


        [HttpPost]
        public int PostOrderD(OrderDetails order)
        {
            _context.OrderD.Add(order);
            _context.SaveChanges();
            return order.Id;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderD(int id, OrderDetails order)
        {
            var existingA = _context.OrderD.FirstOrDefault(a => a.Id == id);
            if (existingA == null)
            {
                return NotFound();
            }

            existingA.Bookcount = order.Bookcount;

            _context.SaveChanges();
            return NoContent();
        }



        [HttpDelete]
        public void DeleteOreder([FromBody] OrderDetails order)
        {
            var updA = _context.OrderD.FirstOrDefault(a => a.Bookcount == order.Bookcount);

            if (updA != null)
            {
                _context.OrderD.Remove(updA);
                _context.SaveChanges();
            }

        }

    }
}
