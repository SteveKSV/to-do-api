using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IToDoItemRepository : IGenericRepository<ToDoItem>
    {
        Task<ToDoItem?> GetByTitle(string title);
    }
}
