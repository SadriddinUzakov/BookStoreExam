using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public ReportController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public Report GetReport(int Id)
        {
            var rep = _context.Report.FirstOrDefault(r => r.Id == Id);
            return rep;
        }


        [HttpGet]
        public List<Report> GetReport()
        {
            var rep = _context.Report.ToList();
            return rep;
        }


        [HttpPost]
        public int PostReport(Report rep)
        {
            _context.Report.Add(rep);
            _context.SaveChanges();
            return rep.Id;
        }

        [HttpPut("{id}")]
        public ActionResult Updatereport(int id, Report rep)
        {
            var existingR = _context.Report.FirstOrDefault(r => r.Id == id);
            if (existingR == null)
            {
                return NotFound();
            }

            existingR.Name = rep.Name;
            existingR.Description = rep.Description;
            existingR.Count = rep.Count;


            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public void DeleteReport([FromBody] Report rep)
        {
            var updR = _context.Report.FirstOrDefault(a => a.Name == rep.Name);

            if (updR != null)
            {
                _context.Report.Remove(updR);
                _context.SaveChanges();
            }
            var updRd = _context.Report.FirstOrDefault(a => a.Description == rep.Description);

            if (updRd != null)
            {
                _context.Report.Remove(updRd);
                _context.SaveChanges();
            }
            var updRc = _context.Report.FirstOrDefault(a => a.Count == rep.Count);

            if (updRc != null)
            {
                _context.Report.Remove(updRc);
                _context.SaveChanges();
            }

        }

    }
}
