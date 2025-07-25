﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public  class CartProduct:BaseAuditingEntity
    {
        public int CartID { get; set; }

        public int ProductID {  get; set; }


        public int Quantity {  get; set; }

       
        public Cart Cart {  get; set; }

        public Product Product { get; set; }    
    }
}
