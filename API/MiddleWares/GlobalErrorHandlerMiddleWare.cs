using System.Linq.Expressions;
using System.Net;
using API.Common;
using Application.Common.Exceptions;
using Microsoft.Extensions.Localization;

namespace API.MiddleWares
{
    public class GlobalErrorHandlerMiddleWare(RequestDelegate next)
    {

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ForbiddenAccessException ex)
            {
                await _buildResponse(context, ex.Message, HttpStatusCode.Forbidden);
            }
            catch (ItemNotFoundException ex)
            {
                await _buildResponse(context, ex.Message, HttpStatusCode.NotFound);
            }
            catch (ValidationException ex)
            {
                await _buildResponse(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private async Task _buildResponse(HttpContext context, string message, HttpStatusCode code)
        {
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsJsonAsync(new GenericReponse { IsSuccess = false, Message = message });
        }

        private async Task _buildResponse(HttpContext context, ValidationException ex, HttpStatusCode code)
        {
            context.Response.StatusCode = (int)code;
            var genericRes = new GenericReponse
            {
                IsSuccess = false,
                Message = ex.Message,
                Errors = ex.Errors
            };
            await context.Response.WriteAsJsonAsync(genericRes);
        }
    }
}
