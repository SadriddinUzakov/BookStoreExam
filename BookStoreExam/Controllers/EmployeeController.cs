using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public EmployeeController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employees>> GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employees> GetEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound($"Employee with Id {id} not found.");
            }

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<int> PostEmployee(Employees employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee.Id);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, Employees employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Employee ID mismatch.");
            }

            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with Id {id} not found.");
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound($"Employee with Id {id} not found.");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
