using Microsoft.EntityFrameworkCore;
using TodoWIthForeginKey.Model;
using Task = TodoWIthForeginKey.Model.Task;

namespace TodoWIthForeginKey.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Work" },
                new Category { Id = 2, Name = "Home" },
                new Category { Id = 3, Name = "Personal" }
            );
           
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, TaskName = "Task 1", CategoryId = 1 },
                new Task { Id = 2, TaskName = "Task 2", CategoryId = 2 },
                new Task { Id = 3, TaskName = "Task 3", CategoryId = 3 }
            );
        }




    }
}
