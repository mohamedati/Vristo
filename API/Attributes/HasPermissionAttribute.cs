using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Common.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace API.Attributes
{
    public class HasPermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                throw new ForbiddenAccessException("InvalidToken");

            }

            var key=System.Text.Encoding.UTF8.GetBytes("your_super_secret_key_123456789");
            var tokenHandler=new JwtSecurityTokenHandler();

            SecurityToken validationResult;

            try
            {
                tokenHandler.ValidateToken(authorizationHeader, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out validationResult);
            }catch(SecurityTokenExpiredException)
            {

                throw new ForbiddenAccessException("InvalidToken");

            }
        }
    }

}
