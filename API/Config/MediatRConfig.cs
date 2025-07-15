using System.Reflection.Metadata;
using Application;
using Application.Common.Behaviours;
using Application.Mapping;
using Mapster;
using MediatR;

namespace API.Config
{
    public static class MediatRConfig
    {
public static void ConfigureMediatR(this IServiceCollection services)
        {
            // Register MediatR services and scan the Application assembly for handlers
            services.AddMediatR(cfg =>
                 cfg.RegisterServicesFromAssembly(typeof(AssemblyReferenceHandler).Assembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            MappingConfiguration.Configure();

            services.AddMapster();
        }
    }
}
