using System.Globalization;
using System.Reflection;
using API.Config;
using API.Extentions;
using API.MiddleWares;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Serilog;
using VristoMarket.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();


builder.Services.AddLocalizationConfig();
builder.Services.AddDbConfig(builder.Configuration);
builder.Services.AddIdentityConfig();
builder.Services.AddCorsPolicy();
builder.Services.ConfigureSerilog(builder.Configuration);
builder.Services.ConfigSwagger();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureMediatR();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog(); // استخدم Serilog بدلاً من Logger الافتراضي




var app = builder.Build();

var supportedCultures = new[] { "en", "ar" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

localizationOptions.RequestCultureProviders = new List<IRequestCultureProvider>
{
    new CustomRequestCultureProvider(context =>
    {
        var culture = context.Request.Headers["culture"].FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(culture) && supportedCultures.Contains(culture))
        {
            return Task.FromResult(new ProviderCultureResult(culture, culture));
        }

        return Task.FromResult(new ProviderCultureResult("en", "en"));
    })
};
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.InitialzeDBAsync().Wait();

app.UseHttpsRedirection();
app.UseMiddleware<GlobalErrorHandlerMiddleWare>();
app.UseRouting();
app.UseRequestLocalization(localizationOptions);

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Uploads")
    ),
    RequestPath = "/Uploads"
});


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
    c.RoutePrefix = ""; 
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
