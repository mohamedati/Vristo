using API.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Extentions
{
    public static  class GenericResponse
    {
        //Extension Methods to Unify the Response of all EndPoints

          public static ActionResult ToGenericResponse<T>(this IEnumerable<T> obj)
        where T : class
        {
            return new OkObjectResult(new GenericReponse { IsSuccess = true, Data = obj });
        }

        public static async Task<ActionResult> ToGenericResponse<T>(this Task<IEnumerable<T>> obj)
            where T : class
        {
            var result = await obj;
            return new OkObjectResult(new GenericReponse { IsSuccess = true, Data = result });
        }

        public static async Task<ActionResult> ToGenericResponse<T>(this Task<T> obj)
            where T : class?
        {
            var result = await obj;
            return new OkObjectResult(new GenericReponse { IsSuccess = true, Data = result });
        }

        public static async Task<ActionResult> ToGenericResponse<T>(this Task<PaginatedList<T>> obj)
            where T : class
        {
            var result = await obj;
            return new OkObjectResult(new GenericReponse { IsSuccess = true, Data = result });
        }

        public static async Task<ActionResult> ToGenericResponse(this Task<int> value)
        {
            var result = await value;
            return new OkObjectResult(new GenericReponse { IsSuccess = true, Data = result });
        }

        public static async Task<ActionResult> ToGenericResponse(this Task<short> value)
        {
            var result = await value;
            return new OkObjectResult(new GenericReponse { IsSuccess = true, Data = result });
        }

        public static async Task<ActionResult> ToGenericResponse(this Task<decimal> value)
        {
            var result = await value;
            return new OkObjectResult(new GenericReponse { IsSuccess = true, Data = result });
        }

        public static async Task<ActionResult> ToGenericResponse(this Task value)
        {
            await value;

            return new OkObjectResult(new GenericReponse { IsSuccess = true, Data = "" });
        }

        public static async Task<ActionResult> ToGenericResponse(this Task<GenericReponse> obj)
        {
            var result = await obj;
            return new OkObjectResult(result);
        }
    }
}
