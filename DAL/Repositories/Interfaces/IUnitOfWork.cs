namespace DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IToDoItemRepository ToDoItemRepository { get; }

        Task SaveChangesAsync();
    }
}
