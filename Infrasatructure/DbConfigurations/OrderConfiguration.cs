using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfigurations
{
    public static class OrderConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");


                entity.Property(a => a.Date).HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(a => a.Creator)
                       .WithMany(a => a.OrderCreatedBy)
                       .HasConstraintName("Fk_Order_CreateBy")
                       .HasForeignKey(a => a.CreatedBy)
                       .OnDelete(deleteBehavior: DeleteBehavior.NoAction);


                entity.HasOne(a => a.Updater)
                     .WithMany(a => a.OrderUpdatedBy)
                     .HasConstraintName("Fk_Order_UpdatedBy")
                     .HasForeignKey(a => a.UpdatedBy)
                     .OnDelete(deleteBehavior: DeleteBehavior.NoAction);



                entity.HasOne(a => a.Deleter)
                   .WithMany(a => a.OrderDeletedBy)
                   .HasConstraintName("Fk_Order_DeletedBy")
                   .HasForeignKey(a => a.DeletedBy)
                   .OnDelete(deleteBehavior: DeleteBehavior.NoAction);






            });
        }
    }
}
