using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ToDoItemRepository : GenericRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(ToDoContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<ToDoItem?> GetByTitle(string title)
        {
            return await _dbContext.ToDoItems.Where(x=> x.Title == title).FirstOrDefaultAsync();
        }
    }
}
