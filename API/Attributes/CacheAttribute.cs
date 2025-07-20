using System.Text.Json;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Attributes
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
      
        private readonly int tTL;

        public CacheAttribute(int TTL)
        {
     
            tTL = TTL;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = context.HttpContext.Request;
            var key = $"{request.Path}{request.QueryString}";


            var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();

            var data=await cacheService.GetByKey(key);

            if (!string.IsNullOrEmpty(data))
            {
                var unescaped = JsonSerializer.Deserialize<string>(data);
                var result= JsonSerializer.Deserialize<Object>(unescaped);
                context.Result = new JsonResult(result)
                {
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
                    await cacheService.SetByKey(key, JSon, TimeSpan.FromMinutes(tTL));
                }
              
               
            }
          

        }

    
    }
}
