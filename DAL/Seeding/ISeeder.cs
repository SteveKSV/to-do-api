using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeding
{
    public interface ISeeder<TEntity> where TEntity : class
    {
        void Seed(EntityTypeBuilder<TEntity> builder);
    }
}
