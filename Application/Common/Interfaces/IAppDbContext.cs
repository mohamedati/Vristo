using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public  interface IAppDbContext
    {

        DbSet<Cart> carts {  get; set; }
        DbSet<CartProduct> cartProducts { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> productCategories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderProduct> OrderProducts { get; set; }


         Task SaveChangesAsync();
    }

}
