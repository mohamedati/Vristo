using Application.Common.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions
{
    public static class DBInitializer
    {
       public static async Task InitialzeDBAsync(this WebApplication webApplication)
        {
            var scope = webApplication.Services.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await service.Database.MigrateAsync();

        }

       
    }
}
