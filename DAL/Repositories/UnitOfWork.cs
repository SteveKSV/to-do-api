using DAL.Data;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ToDoContext _context;
        public IToDoItemRepository ToDoItemRepository { get; }

        public UnitOfWork(ToDoContext context, IToDoItemRepository toDoItemRepository)
        {
            _context = context;
            ToDoItemRepository = toDoItemRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
