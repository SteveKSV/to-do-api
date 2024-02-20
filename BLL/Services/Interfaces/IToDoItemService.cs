using BLL.Dtos;

namespace BLL.Services.Interfaces
{
    public interface IToDoItemService 
    {
        Task<ToDoItemDto> CreateTodoItem(ToDoItemDto todoItem);
        Task<IEnumerable<ToDoItemDto>> GetAllTodoItems();
        Task<ToDoItemDto> GetTodoItemById(Guid id);
        Task<bool> UpdateTodoItem(ToDoItemDto todoItem);
        Task<bool> DeleteTodoItemById(Guid id);

        Task<ToDoItemDto?> GetByTitle(string title);
    }
}
