using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AuthorsController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public Author GetAuthors(int Id)
        {
            var avtor = _context.Author.FirstOrDefault(a => a.Id == Id);
            return avtor;
        }


        [HttpGet]
        public List<Author> GetAuthor()
        {
            var avtor = _context.Author.ToList();
            return avtor;
        }


        [HttpPost]
        public int PostAuthor(Author avtor)
        {
            _context.Author.Add(avtor);
            _context.SaveChanges();
            return avtor.Id;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAuthor(int id, Author avtor)
        {
            var existingA = _context.Author.FirstOrDefault(a => a.Id == id);
            if (existingA == null)
            {
                return NotFound();
            }

            existingA.Name = avtor.Name;




            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public void DeleteAuthor([FromBody] Author avtor)
        {
            var updA = _context.Author.FirstOrDefault(a => a.Name == avtor.Name);

            if (updA != null)
            {
                _context.Author.Remove(updA);
                _context.SaveChanges();
            }

        }

    }
}
