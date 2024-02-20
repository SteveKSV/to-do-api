using DAL.Data;
using DAL.Exceptions;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ToDoContext _dbContext;
        private readonly DbSet<TEntity> table;
        public GenericRepository(ToDoContext databaseContext)
        {
            _dbContext = databaseContext;
            table = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await table.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await table.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            table.Remove(entity);
            return await SaveAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await table.FindAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException(
                GetEntityNotFoundErrorMessage(id));
            }

            return entity;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _dbContext.Update(entity);
            return await SaveAsync();
        }

        protected static string GetEntityNotFoundErrorMessage(Guid id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";
        public async Task<bool> SaveAsync()
        {
            var saved = await _dbContext.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
