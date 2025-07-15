using System.Reflection.Metadata;
using Application;
using Application.Areas.Account.Commands.ForgetPasswordCommand;
using Application.Areas.Account.Commands.LoginCommand;
using Application.Common.Behaviours;
using Application.Mapping;
using FluentValidation;
using FluentValidation.Results;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Config
{
    public static class MediatRConfig
    {
public static void ConfigureMediatR(this IServiceCollection services)
        {
            // Register MediatR services and scan the Application assembly for handlers
            services.AddMediatR(cfg =>
                 cfg.RegisterServicesFromAssembly(typeof(AssemblyReferenceHandler).Assembly));

            services.AddValidatorsFromAssembly(typeof(LoginCommandValidator).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));



            // default response for invalid model state
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context
                        .ModelState.Where(entry => entry.Value.Errors.Count > 0)
                        .Select(entry => new ValidationFailure
                        {
                            PropertyName = string.IsNullOrWhiteSpace(entry.Key) ? "otherErrors" : entry.Key,
                            ErrorMessage = entry.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault() ?? "",
                        });

                    throw new ValidationException(errors);
                };
            });

            MappingConfiguration.Configure();

            services.AddMapster();
        }
    }
}
