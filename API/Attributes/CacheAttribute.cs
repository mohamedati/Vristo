using System.Text.Json;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Attributes
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly ICacheService cacheService;
        private readonly TimeSpan tTL;

        public CacheAttribute(ICacheService cacheService,TimeSpan TTL)
        {
            this.cacheService = cacheService;
            tTL = TTL;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var Key=context.HttpContext.Request.Path.ToString();

            var data=await cacheService.GetByKey(Key);

            if (!string.IsNullOrEmpty(data))
            {
                context.Result = new ContentResult
                {
                    Content = data,
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }
            else
            {
                var actionExecutedContext=await next();

                if(actionExecutedContext.Result is ObjectResult objectResult && objectResult.Value != null)
                {
                    var JSon = JsonSerializer.Serialize(objectResult.Value);
                    await cacheService.SetByKey(Key, JSon, tTL);
                }
              
               
            }
          

        }

    
    }
}
