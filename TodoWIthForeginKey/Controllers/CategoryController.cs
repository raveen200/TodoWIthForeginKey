using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TodoWIthForeginKey.Data;
using TodoWIthForeginKey.Model;

namespace TodoWIthForeginKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
       public async Task<ActionResult> GetCategories()
        {
            var categories = await _db.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id , Category category)
        {
            var CategoryData = await _db.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (CategoryData == null)
            {
                return NotFound();
            }

            CategoryData.Name = category.Name;

            await _db.SaveChangesAsync();
            return Ok(CategoryData);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
             _db.Categories.Remove(category);

            await _db.SaveChangesAsync();
            return Ok();
        }





    }
}
