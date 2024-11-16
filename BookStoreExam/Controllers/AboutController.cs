using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AboutController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<About> GetAbout(int id)
        {
            var about = _context.About.FirstOrDefault(a => a.Id == id);
            if (about == null)
            {
                return NotFound();
            }
            return about;
        }

        [HttpGet]
        public ActionResult<IEnumerable<About>> GetAllAbout()
        {
            return _context.About.ToList();
        }

        [HttpPost]
        public ActionResult<About> CreateAbout(About about)
        {
            _context.About.Add(about);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAbout), new { id = about.Id }, about);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAbout(int id, About about)
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

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var about = _context.About.FirstOrDefault(a => a.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            _context.About.Remove(about);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
