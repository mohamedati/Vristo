using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace VristoMarket.Config
{
    public static class CorsConfiguration
    {
        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
                });
            });
        }
    }
}
