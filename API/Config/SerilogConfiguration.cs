using Serilog;

namespace API.Config
{
    public static  class SerilogConfiguration
    {

        public static void ConfigureSerilog(this IServiceCollection services,IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();

          
        }
    }
}
