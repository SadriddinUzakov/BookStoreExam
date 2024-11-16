using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AdressController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AdressController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public Adress GetAdress(int Id)
        {
            var adres = _context.Adress.FirstOrDefault(adres => adres.Id == Id);
            return adres;
        }


        [HttpGet]
        public List<Adress> GetAdress()
        {
            var adres = _context.Adress.ToList();
            return adres;
        }


        [HttpPost]
        public int PostAdress(Adress adres)
        {
            _context.Adress.Add(adres);
            _context.SaveChanges();
            return adres.Id;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAdress(int id, Adress adres)
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

        [HttpDelete]
        public void DeleteAdress([FromBody] Adress adres)
        {
            var updA = _context.Adress.FirstOrDefault(a => a.Region == adres.Region);

            if (updA != null)
            {
                _context.Adress.Remove(updA);
                _context.SaveChanges();
            }
            var updAS = _context.Adress.FirstOrDefault(a => a.Street == adres.Street);

            if (updAS != null)
            {
                _context.Adress.Remove(updAS);
                _context.SaveChanges();
            }
            var updAC = _context.Adress.FirstOrDefault(a => a.City == adres.City);

            if (updAC != null)
            {
                _context.Adress.Remove(updAC);
                _context.SaveChanges();
            }
        }

    }
}
