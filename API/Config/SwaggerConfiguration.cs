using System;
using Microsoft.OpenApi.Models;

namespace API.Config
{
    public static class SwaggerConfiguration
    {
        public static void ConfigSwagger(this IServiceCollection Services)
        {
            Services.AddSwaggerGen(c =>
            {
                c.OperationFilter<LanguageHeaderOperationFilter>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT Token Here",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Beare",
                    BearerFormat = "JWT",

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });
       
        }
    }
}
