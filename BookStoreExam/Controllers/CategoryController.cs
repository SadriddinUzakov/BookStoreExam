using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public CategoryController(BookStoreContext context)
        {
            _context = context;
        }


        [HttpPost]
        public int PostCategory(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return category.Id;
        }


        [HttpGet]
        public List<Category> GetCategory()
        {
            return _context.Category.ToList();
        }



        [HttpPut]
        public void UpdateCategory(Category category)
        {
            var existingCategory = _context.Category.FirstOrDefault(c => c.Id == category.Id);

            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;

                _context.SaveChanges();
            }
        }


        [HttpDelete]
        public void DeleteCategory(int id)
        {
            var updCategory = _context.Category.FirstOrDefault(category => category.Id == id);

            if (updCategory != null)
            {
                _context.Category.Remove(updCategory);
                _context.SaveChanges();
            }
        }

    }


}
