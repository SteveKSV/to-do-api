using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeding
{
    public class ToDoItemSeeder : ISeeder<ToDoItem>
    {
        private readonly List<ToDoItem> todoItems = new()
        {
            new ToDoItem {
                Id = Guid.NewGuid(),
                Title="Shopping",
                Description="Buy milk, chocolate and bread.",
                Status = false
            },
            new ToDoItem {
                Id = Guid.NewGuid(),
                Title="Finish homework",
                Description="",
                Status = true
            },
            new ToDoItem {
                Id = Guid.NewGuid(),
                Title="Cram at night",
                Description="Revise materials for exam, which will happen at 14:00 tomorrow.",
                Status = false
            },
        };

        public void Seed(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.HasData(todoItems);
        }
    }
}
