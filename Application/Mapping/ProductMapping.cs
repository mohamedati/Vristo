using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Areas.Product.Queries.PaginateProducts;
using Domain.Entities;
using Mapster;

namespace Application.Mapping
{
    public static class ProductMapping
    {
        public static void Run()
        {
            TypeAdapterConfig<Product, ProductDTO>.NewConfig()
               .Map(src=>src.CountOfOrders,dest=>dest.OrderProducts.Count())
               .Map(src=>src.CategoryArName,dest=>dest.Category.ArName)
               .Map(src => src.CategoryEnName, dest => dest.Category.EnName);
        
        }
    }
}
