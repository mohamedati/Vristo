using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Product : BaseAuditableEntity<int>
    {

        public string ArName {  get; set; }

        public string EnName {  get; set; }

        public string ArTitle {  get; set; }

        public string EnTitle { get; set; }

        public string ArDescription {  get; set; }


        public string EnDescription { get; set; }


        public decimal Price {  get; set; }

        public int Quantity {  get; set; }

        public bool UsersNotified {  get; set; }

        public int CategoryID { get; set; }
        public IEnumerable<CartProduct> CartProducts { get; set; }

        public IEnumerable<OrderProduct> OrderProducts { get; set; }

        public ProductCategory Category { get; set; }

    }
}
