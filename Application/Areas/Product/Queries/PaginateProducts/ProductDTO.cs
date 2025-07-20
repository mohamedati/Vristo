using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Areas.Product.Queries.PaginateProducts
{
    public  class ProductDTO
    {
        public int Id { get; set; }
        public string ArName { get; set; } = null!;

        public string EnName { get; set; } = null!;

        public string ArTitle { get; set; } = null!;

        public string EnTitle { get; set; } = null!;

        public string ArDescription { get; set; } = null!;


        public string EnDescription { get; set; } = null!;


        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageName { get; set; }

        public int CategoryID { get; set; }

        public long CountOfOrders {  get; set; }

        public string CategoryArName { get; set; }

        public string CategoryEnName { get; set; }
    }
}
