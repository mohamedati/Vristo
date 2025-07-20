using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Common.Pagination
{
    public  class PaginationQuery<T> :IRequest<T> where T : class
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 10;

        public string SortBy { get; set; } = "";


        public string Search { get; set; } = "";

        public string SortOrder { get; set; } = "";
    }
}
