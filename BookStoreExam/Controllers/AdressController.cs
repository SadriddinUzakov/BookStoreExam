using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdressController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AdressController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public ActionResult<About>GetAbout(int Id)
        {
            var adres = _context.Adress.FirstOrDefault(adres => adres.Id == Id);
            if (adres == null)
            {
                return NotFound();
            }
            else
                return Ok(adres);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Adress>> GetAdresses()
        {
            return _context.Adress.ToList();
        }


        [HttpPost]
        public ActionResult<Adress> CreateAdres(Adress adress)
        {
            _context.Adress.Add(adress);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAdresses), new { id = adress.Id }, adress);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdress(int id, Adress adres)
        {
            var existingA = _context.Adress.FirstOrDefault(a => a.Id == id);
            if (existingA == null)
            {
                return NotFound();
            }

            existingA.Region = adres.Region;
            existingA.City = adres.City;
            existingA.Street = adres.Street;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdress(int id)
        {
            var adres = _context.Adress.FirstOrDefault(a => a.Id == id);
            if (adres == null)
            {
                return NotFound();
            }

            _context.Adress.Remove(adres);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
