using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AuthorsController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
        {
            var authors = _context.Author.ToList();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = _context.Author.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound($"Author with Id {id} not found.");
            }
            return Ok(author);
        }

        [HttpPost]
        public ActionResult<int> PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Author.Add(author);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author.Id);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest("Author ID mismatch.");
            }

            var existingAuthor = _context.Author.FirstOrDefault(a => a.Id == id);
            if (existingAuthor == null)
            {
                return NotFound($"Author with Id {id} not found.");
            }

            existingAuthor.Name = author.Name;

            _context.SaveChanges();
            return NoContent();
        }

        // Delete an author by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            var author = _context.Author.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound($"Author with Id {id} not found.");
            }

            _context.Author.Remove(author);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
