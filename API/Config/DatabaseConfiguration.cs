using API.Interceptors;
using Application.Common.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace VristoMarket.Config
{
    public static class DatabaseConfiguration
    {
        public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                var interceptor = sp.GetRequiredService<AuditableEntitySaveChangesInterceptor>();
                options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .AddInterceptors(interceptor);
            });

            //Register services

            services.AddScoped<IJWTService, JWTService>();
            services.AddSingleton<IStorageService, StorageService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


        }
    }
}
