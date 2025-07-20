using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Common;
using Application.Common.Interfaces;
using Application.Common.Pagination;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Areas.Product.Queries.PaginateProducts
{
    public  class PaginateProducts:PaginationQuery<PaginatedList<ProductDTO>>
    {
        public int? CategoryID { get; set; }
    }

    public class PaginateProductsHandler
        (IAppDbContext appDb)
        : IRequestHandler<PaginateProducts, PaginatedList<ProductDTO>>
    {
        public  async Task<PaginatedList<ProductDTO>> Handle(PaginateProducts request, CancellationToken cancellationToken)
        {
            return await appDb.Products
                .Include(a => a.Category)
                .Include(a => a.OrderProducts)
                .Where(a => request.Search.Trim() == ""
                || a.ArName.Contains(request.Search)
                || a.EnName.Contains(request.Search))
                .Where(a => !request.CategoryID.HasValue || a.CategoryID == request.CategoryID)
                .ProjectToType<ProductDTO>()
                .sort(request.SortBy, request.SortOrder)
                .PaginateAsync(request.Size, request.Page);
                
        }
    }
}
