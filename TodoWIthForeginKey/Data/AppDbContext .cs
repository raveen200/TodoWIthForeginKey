using Microsoft.EntityFrameworkCore;
using TodoWIthForeginKey.Model;

namespace TodoWIthForeginKey.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Work" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Home" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Personal" });

            modelBuilder.Entity<Item>().HasData(new Item { Id = 1, TaskName = "Work Task 1", CategoryId = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { Id = 2, TaskName = "Work Task 2", CategoryId = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { Id = 3, TaskName = "Home Task 1", CategoryId = 2 });
            modelBuilder.Entity<Item>().HasData(new Item { Id = 4, TaskName = "Home Task 2", CategoryId = 2 });
            modelBuilder.Entity<Item>().HasData(new Item { Id = 5, TaskName = "Personal Task 1", CategoryId = 3 });


        }






    }
}
