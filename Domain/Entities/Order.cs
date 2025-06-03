using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public  class Order:BaseAuditableEntity<long>
    {
        public string UserID {  get; set; }

        public DateTime Date {  get; set; }

        public IEnumerable<OrderProduct> OrderProducts { get; set; }

    }
}
