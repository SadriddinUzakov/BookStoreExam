using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public ReportController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Report>> GetReports()
        {
            var reports = _context.Report.ToList();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public ActionResult<Report> GetReport(int id)
        {
            var report = _context.Report.FirstOrDefault(r => r.Id == id);
            if (report == null)
            {
                return NotFound($"Report with Id {id} not found.");
            }
            return Ok(report);
        }

        [HttpPost]
        public ActionResult<int> PostReport(Report report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Report.Add(report);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetReport), new { id = report.Id }, report.Id);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateReport(int id, Report report)
        {
            if (id != report.Id)
            {
                return BadRequest("Report ID mismatch.");
            }

            var existingReport = _context.Report.FirstOrDefault(r => r.Id == id);
            if (existingReport == null)
            {
                return NotFound($"Report with Id {id} not found.");
            }

            existingReport.Name = report.Name;
            existingReport.Description = report.Description;
            existingReport.Count = report.Count;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReport(int id)
        {
            var report = _context.Report.FirstOrDefault(r => r.Id == id);
            if (report == null)
            {
                return NotFound($"Report with Id {id} not found.");
            }

            _context.Report.Remove(report);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
