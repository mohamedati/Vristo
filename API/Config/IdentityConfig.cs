using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;

namespace API.Config
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfig(this IServiceCollection services)
        {

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    // Password settings
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;

                    // User settings
                    options.User.RequireUniqueEmail = true;

                    // Token settings
                    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
                    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                })
               .AddEntityFrameworkStores<AppDbContext>()
                   
               .AddErrorDescriber<LocalizedIdentityErrorDescriber>()


               .AddDefaultTokenProviders();

        }
    }
}
