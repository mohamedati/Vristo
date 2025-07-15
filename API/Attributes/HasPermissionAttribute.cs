using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Common.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace API.Attributes
{
    public class HasPermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var scope = context.HttpContext.RequestServices.CreateScope();
            var Localizer = scope.ServiceProvider.GetRequiredService<IStringLocalizer<Resources.Resources>>();
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var lang = context.HttpContext.Request.Headers["culture"].FirstOrDefault();
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                throw new ForbiddenAccessException(Localizer["InvalidToken"]);

            }

            var key=System.Text.Encoding.UTF8.GetBytes("your_super_secret_key_123456789101112");
            var tokenHandler=new JwtSecurityTokenHandler();

            SecurityToken validationResult;

            try
            {
                var principal= tokenHandler.ValidateToken(authorizationHeader, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out _);

                context.HttpContext.User = principal;

            }
            catch (SecurityTokenExpiredException)
            {

                throw new ForbiddenAccessException("InvalidToken");

            }
        }
    }

}
