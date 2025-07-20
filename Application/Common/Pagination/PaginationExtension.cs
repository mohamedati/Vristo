using API.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Common.Pagination
{
    public static  class PaginationExtension
    {
        public static async Task<PaginatedList<T>> PaginateAsync<T>(this IQueryable<T> data, int pageSize, int page) {

            var result = await data.ToListAsync();

            return new PaginatedList<T>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = result.Count(),
                Items = result.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };


        }

        public static IQueryable<T> sort<T>(this IQueryable<T> data, string SortColumn ,string SortDirection)
        {
            var property = typeof(T)
                 .GetProperty(SortColumn, System.Reflection.BindingFlags.IgnoreCase |
                         System.Reflection.BindingFlags.Public |
                         System.Reflection.BindingFlags.Instance);

            if (property is null)
                SortColumn = "ID";

            var direction = SortDirection?.ToLower() == "desc" ? "descending" : "ascending";

            return data.OrderBy($"{SortColumn} {direction}");




        }
    }
}
