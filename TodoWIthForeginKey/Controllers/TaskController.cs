using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWIthForeginKey.Data;
using TodoWIthForeginKey.Model;
using TodoWIthForeginKey.Model.DTO;

namespace TodoWIthForeginKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TaskController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<ActionResult> GetTasks()
        {
            var tasks = await _db.Items
                .Include(t => t.Category)
                .Select(t => new
                {
                    t.Id,
                    t.TaskName,
                    t.CategoryId,
                    CategoryName = t.Category.Name
                })
                .ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTask(int id)
        {
            var task = await _db.Items
                .Include(t => t.Category)
                .Select(t => new
                {
                    t.Id,
                    t.TaskName,
                    t.CategoryId,
                    CategoryName = t.Category.Name
                })
                .FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<ItemRequset>> AddItem(ItemRequset itemRequset)
        {
            var item = new Item
            {
                TaskName = itemRequset.TaskName,
                CategoryId = itemRequset.CategoryId
            };

            await _db.Items.AddAsync(item);
            await _db.SaveChangesAsync();
            return Ok(StatusCode(201));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, ItemRequset itemRequset)
        {
            var task = _db.Items.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            task.TaskName = itemRequset.TaskName;
            task.CategoryId = itemRequset.CategoryId;
            await _db.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveItem(int id)
        {
            var task = _db.Items.FirstOrDefault(x => x.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            _db.Items.Remove(task);
            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}


