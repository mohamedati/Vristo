using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public  class ProductCategory:BaseAuditableEntity<int>
    {

       public string ArName {  get; set; }

        public string EnName { get; set; }

        public string ArDescription { get; set; }


        public string EnDescription { get; set; }

        public IEnumerable<Product> Product { get; set; }
    }
}
