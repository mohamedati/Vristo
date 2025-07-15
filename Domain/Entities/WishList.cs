using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public  class WishList: BaseAuditableEntity<long>
    {
        public string CustomerID {  get; set; }

        public int ProductID { get; set; }

        public ApplicationUser User { get; set; }

        public Product Product { get; set; }
    }
}
