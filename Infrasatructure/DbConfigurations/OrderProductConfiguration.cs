using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.DbConfigurations
{
    public static class OrderProductConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.ToTable("OrderProduct");

                entity.HasKey(a => new { a.OrderId, a.ProductId });


                entity.HasOne(a => a.Order)
                 .WithMany(a => a.OrderProducts)
                 .HasConstraintName("FK_Order_OrderProducts")
                 .HasForeignKey(a => a.OrderId)
                 .OnDelete(deleteBehavior: DeleteBehavior.NoAction); ;


                entity.HasOne(a => a.Product)
              .WithMany(a => a.OrderProducts)
              .HasConstraintName("FK_Product_OrderProducts")
              .HasForeignKey(a => a.ProductId)
              .OnDelete(deleteBehavior: DeleteBehavior.NoAction); ;


                entity.HasOne(a => a.Creator)
                      .WithMany(a => a.OrderProductsCreatedBy)
                      .HasConstraintName("Fk_OrderProduct_CreateBy")
                      .HasForeignKey(a => a.CreatedBy)
                      .OnDelete(deleteBehavior: DeleteBehavior.NoAction);


                entity.HasOne(a => a.Updater)
                     .WithMany(a => a.OrderProductsUpdatedBy)
                     .HasConstraintName("Fk_OrderProduct_UpdatedBy")
                     .HasForeignKey(a => a.UpdatedBy)
                     .OnDelete(deleteBehavior: DeleteBehavior.NoAction);



                entity.HasOne(a => a.Deleter)
                   .WithMany(a => a.OrderProductsDeletedBy)
                   .HasConstraintName("Fk_OrderProduct_DeletedBy")
                   .HasForeignKey(a => a.DeletedBy)
                   .OnDelete(deleteBehavior: DeleteBehavior.NoAction);






            });
        }
    }
}
