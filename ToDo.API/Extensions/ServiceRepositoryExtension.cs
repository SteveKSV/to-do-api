using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace ToDo.API.Extensions
{
    public static class ServiceRepositoryExtension
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IToDoItemService, ToDoItemService>();
        }

        public static void AddDALRepositories(this IServiceCollection services)
        {
            services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
