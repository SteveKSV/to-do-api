using AutoMapper;
using BLL.Dtos;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }
        public ToDoItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<ToDoItemDto> CreateTodoItem(ToDoItemDto todoItem)
        {
            var entity = Mapper.Map<ToDoItem>(todoItem);
            var response = await UnitOfWork.ToDoItemRepository.CreateAsync(entity);

            return Mapper.Map<ToDoItemDto>(response);
        }

        public async Task<bool> DeleteTodoItemById(Guid id)
        {
            var response = await UnitOfWork.ToDoItemRepository.DeleteAsync(id);
            return response;
        }

        public async Task<IEnumerable<ToDoItemDto>> GetAllTodoItems()
        {
            var response = await UnitOfWork.ToDoItemRepository.GetAllAsync();

            return Mapper.Map<IEnumerable<ToDoItemDto>>(response);
        }

        public async Task<ToDoItemDto> GetTodoItemById(Guid id)
        {
            var response = await UnitOfWork.ToDoItemRepository.GetByIdAsync(id);
            return Mapper.Map<ToDoItemDto>(response);
        }

        public async Task<bool> UpdateTodoItem(ToDoItemDto todoItem)
        {
            var response = await UnitOfWork.ToDoItemRepository.UpdateAsync(Mapper.Map<ToDoItem>(todoItem));
            return response;
        }

        public async Task<ToDoItemDto?> GetByTitle(string title)
        {
            var response = await UnitOfWork.ToDoItemRepository.GetByTitle(title);
            return Mapper.Map<ToDoItemDto>(response);
        }
    }
}
