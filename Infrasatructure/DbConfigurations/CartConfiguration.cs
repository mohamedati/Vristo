using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfigurations
{
    public static  class CartConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasOne(a => a.Creator)
                  .WithMany(a => a.CartsCreatedBy)
                  .HasConstraintName("Fk_Cart_CreateBy")
                  .HasForeignKey(a => a.CreatedBy)
                  .OnDelete(deleteBehavior: DeleteBehavior.NoAction);


                entity.HasOne(a => a.Updater)
               .WithMany(a => a.CartsUpdatedBy)
               .HasConstraintName("Fk_Cart_UpdatedBy")
               .HasForeignKey(a => a.UpdatedBy)
               .OnDelete(deleteBehavior: DeleteBehavior.NoAction);



                entity.HasOne(a => a.Deleter)
               .WithMany(a => a.CartsDeletedBy)
               .HasConstraintName("Fk_Cart_DeletedBy")
               .HasForeignKey(a => a.DeletedBy)
               .OnDelete(deleteBehavior: DeleteBehavior.NoAction);









            });
        }
    }
}
