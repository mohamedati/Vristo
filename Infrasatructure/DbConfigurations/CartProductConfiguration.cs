using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfigurations
{
    public static class CartProductConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartProduct>(entity =>
            {
                entity.ToTable("CartProduct");

                entity.HasKey(a => new { a.ProductID, a.CartID });
                entity.HasOne(a => a.Cart)
                 .WithMany(a => a.cartProducts)
                 .HasConstraintName("FK_Cart_cartProducts")
                 .HasForeignKey(a => a.CartID)
                 .OnDelete(deleteBehavior: DeleteBehavior.NoAction); ;


                entity.HasOne(a => a.Product)
              .WithMany(a => a.CartProducts)
              .HasConstraintName("FK_Product_cartProducts")
              .HasForeignKey(a => a.ProductID)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);


                entity.HasOne(a => a.Creator)
                .WithMany(a => a.CartProductsCreatedBy)
                .HasConstraintName("Fk_cartProducts_CreateBy")
                .HasForeignKey(a => a.CreatedBy)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);


                entity.HasOne(a => a.Updater)
               .WithMany(a => a.CartProductsUpdatedBy)
               .HasConstraintName("Fk_cartProducts_UpdatedBy")
               .HasForeignKey(a => a.UpdatedBy)
               .OnDelete(deleteBehavior: DeleteBehavior.NoAction);



                entity.HasOne(a => a.Deleter)
               .WithMany(a => a.CartProductsDeletedBy)
               .HasConstraintName("Fk_cartProducts_DeletedBy")
               .HasForeignKey(a => a.DeletedBy)
               .OnDelete(deleteBehavior: DeleteBehavior.NoAction);








            });
        }
    }
}
