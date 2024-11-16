using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public BookController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound($"Book with Id {id} not found.");
            }

            return Ok(book);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }

        [HttpPost]
        public ActionResult<int> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book.Id);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Book ID mismatch.");
            }

            var existingBook = _context.Books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound($"Book with Id {id} not found.");
            }

            existingBook.Title = book.Title;
            existingBook.Price = book.Price;
            existingBook.CategoryId = book.CategoryId;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound($"Book with Id {id} not found.");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
