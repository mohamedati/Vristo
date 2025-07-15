using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.DbConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public  class AppDbContext:IdentityDbContext<ApplicationUser>,IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts) { }

        public DbSet<Cart> carts { get  ; set; }
        public DbSet<CartProduct> cartProducts { get  ; set  ; }
        public DbSet<Product> Products { get  ; set  ; }
        public DbSet<ProductCategory> productCategories { get  ; set  ; }
        public DbSet<Order> Orders { get  ; set  ; }
        public DbSet<OrderProduct> OrderProducts { get  ; set  ; }

        public DbSet<WishList> wishLists { get; set; }

        public  async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ConfigureDB.Configure(builder);
            builder.Entity<ProductCategory>()
                .HasQueryFilter(a => a.DeletedAt == null);

            builder.Entity<Product>()
              .HasQueryFilter(a => a.DeletedAt == null);
        }
  


    }
}
