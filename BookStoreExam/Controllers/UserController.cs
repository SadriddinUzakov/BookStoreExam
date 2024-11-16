using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public UserController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public User GetUser(int Id)
        {
            var user = _context.User.FirstOrDefault(u => u.Id == Id);
            return user;
        }


        [HttpGet]
        public List<User> GetUser()
        {
            var user = _context.User.ToList();
            return user;
        }


        [HttpPost]
        public int PostOrder(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User user)
        {
            var existingA = _context.User.FirstOrDefault(a => a.Id == id);
            if (existingA == null)
            {
                return NotFound();
            }

            existingA.Name = user.Name;
            existingA.Password = user.Password;
            existingA.Email = user.Email;



            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public void DeleteOreder([FromBody] User user)
        {
            var updA = _context.User.FirstOrDefault(a => a.Name == user.Name);

            if (updA != null)
            {
                _context.User.Remove(updA);
                _context.SaveChanges();
            }
            var updn = _context.User.FirstOrDefault(a => a.Password == user.Password);

            if (updn != null)
            {
                _context.User.Remove(updn);
                _context.SaveChanges();
            } 
            var upde = _context.User.FirstOrDefault(a => a.Email == user.Email);

            if (upde != null)
            {
                _context.User.Remove(upde);
                _context.SaveChanges();
            }

        }

    }
}
