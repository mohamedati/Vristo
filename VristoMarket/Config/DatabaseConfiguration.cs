using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace VristoMarket.Config
{
    public static class DatabaseConfiguration
    {
        public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
