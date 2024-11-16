using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public CategoryController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _context.Category.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound($"Category with Id {id} not found.");
            }

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<int> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Category.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category.Id);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest("Category ID mismatch.");
            }

            var existingCategory = _context.Category.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound($"Category with Id {id} not found.");
            }

            existingCategory.Name = category.Name;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound($"Category with Id {id} not found.");
            }

            _context.Category.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
