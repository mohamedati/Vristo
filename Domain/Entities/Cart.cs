using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public  class Cart:BaseAuditableEntity<int>
    {

        public ApplicationUser ApplicationUser {  get; set; }
        public IEnumerable<CartProduct> cartProducts { get; set; }


    }
}
