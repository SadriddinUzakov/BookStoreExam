using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AboutController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public About Getabout(int Id)
        {
            var about = _context.About.FirstOrDefault(about => about.Id == Id);
            return about;
        }


        [HttpGet]
        public List<About> GetAbout()
        {
            var about = _context.About.ToList();
            return about;
        }


        [HttpPost]
        public int PostAbout(About about)
        {
            _context.About.Add(about);
            _context.SaveChanges();
            return about.Id;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAbout(int id, About about)
        {
            var existingAbout = _context.About.FirstOrDefault(a => a.Id == id);
            if (existingAbout == null)
            {
                return NotFound();
            }

            existingAbout.Name = about.Name;



            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public void DeleteAbout([FromBody] About about)
        {
            var updA = _context.About.FirstOrDefault(a => a.Name == about.Name);

            if (updA != null)
            {
                _context.About.Remove(updA);
                _context.SaveChanges();
            }
        }

    }
}
