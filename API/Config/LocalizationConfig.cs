using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace API.Config
{
    public static class LocalizationConfig
    {
        public static void AddLocalizationConfig(this IServiceCollection services)
        {
            services.AddLocalization();

          services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "en", "ar" };

                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
                options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();

                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    var lang = context.Request.Headers["culture"].FirstOrDefault();
                    var culture = string.IsNullOrWhiteSpace(lang) ? "en" : lang;
                    return Task.FromResult(new ProviderCultureResult(culture, culture));
                }));
            });
        }
    }
}
