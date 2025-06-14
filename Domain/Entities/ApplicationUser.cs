using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public  class ApplicationUser:IdentityUser
    {
        public int CartID { get; set; }
        
        public Cart Cart { get; set; }

        public string RefreshToken {  get; set; }

        public DateTime RefreshTokenExpiredAt { get; set; }
        public IEnumerable<Cart> CartsCreatedBy { get; set; }

        public IEnumerable<Cart> CartsUpdatedBy { get; set; }


        public IEnumerable<Cart> CartsDeletedBy { get; set; }

        public IEnumerable<Product>ProductsCreatedBy { get; set; }
        public IEnumerable<Product> ProductsUpdatedBy { get; set; }
        public IEnumerable<Product> ProductsDeletedBy { get; set; }



        public IEnumerable<ProductCategory> ProductCategoriesCreatedBy { get; set; }
        public IEnumerable<ProductCategory> ProductCategoriesUpdatedBy { get; set; }
        public IEnumerable<ProductCategory> ProductCategoriesDeletedBy { get; set; }



        public IEnumerable<CartProduct> CartProductsCreatedBy { get; set; }
        public IEnumerable<CartProduct> CartProductsUpdatedBy { get; set; }
        public IEnumerable<CartProduct> CartProductsDeletedBy { get; set; }



        public IEnumerable<OrderProduct> OrderProductsCreatedBy { get; set; }
        public IEnumerable<OrderProduct> OrderProductsUpdatedBy { get; set; }
        public IEnumerable<OrderProduct> OrderProductsDeletedBy { get; set; }

        public IEnumerable<Order> OrderCreatedBy { get; set; }
        public IEnumerable<Order> OrderUpdatedBy { get; set; }
        public IEnumerable<Order> OrderDeletedBy { get; set; }

      


    }
}
