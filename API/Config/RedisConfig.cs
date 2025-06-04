using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace API.Config
{
    public static class RedisConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis")!, true);
            return ConnectionMultiplexer.Connect(config);
        });

            services.AddScoped<ICacheService, CacheService>();

            return services;
        }
    }
}
