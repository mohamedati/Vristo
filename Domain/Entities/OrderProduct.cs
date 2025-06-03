using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public  class OrderProduct:BaseAuditingEntity
    {
        public int ProductId {  get; set; }

        public long OrderId {  get; set; }

        public int Quantity {  get; set; }


        public Order Order { get; set; }

        public Product Product { get; set; }



    }
}
