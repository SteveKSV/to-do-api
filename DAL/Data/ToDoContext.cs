using DAL.Data.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
        }
    }
}
