
using Application.Common.Interfaces;
using BackgroundJob.Jobs;
using Hangfire;
using Hangfire.SqlServer;
using Infrastructure.Contexts;
using Infrastructure.Services;
using API.Config;
using VristoMarket.Config;
using Serilog;

namespace BackgroundJob
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Hangfire services.
            builder.Services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(builder.Configuration.GetConnectionString("Jobsconnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                });
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddLocalizationConfig();
            builder.Services.AddDbConfig(builder.Configuration);
            builder.Services.AddIdentityConfig();
  
            builder.Services.ConfigSwagger();
     
            builder.Services.AddInfrastructure(builder.Configuration);
          

            builder.Services.AddHangfireServer();

            var app = builder.Build();

            // Use Hangfire Dashboard
            app.UseHangfireDashboard("/hangfire");


            RecurringJob.AddOrUpdate<ProductJobs>(
              "product-email-job",
              job => job.SendProductNotification(),
                 Cron.Hourly);


            app.Run();

        }

    }
    }
