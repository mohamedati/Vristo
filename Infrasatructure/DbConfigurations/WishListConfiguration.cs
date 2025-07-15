using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfigurations
{
    public static  class WishListConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");
                entity.Property(a => a.CustomerID).HasMaxLength(450);
                entity.HasOne(a => a.User)
                    .WithMany(a => a.Wishes)
                    .HasConstraintName("FK_WishList_Customer")
                    .HasForeignKey(a => a.CustomerID)
                    .IsRequired();

                entity.HasOne(a => a.Product)
                 .WithMany(a => a.Wishes)
                 .HasConstraintName("FK_WishList_Product")
                 .HasForeignKey(a => a.ProductID)
                 .IsRequired();


                entity.HasOne(a => a.Creator)
                       .WithMany(a => a.WishListCreatedBy)
                       .HasConstraintName("Fk_WishList_CreateBy")
                       .HasForeignKey(a => a.CreatedBy)
                       .OnDelete(deleteBehavior: DeleteBehavior.NoAction);


                entity.HasOne(a => a.Updater)
                     .WithMany(a => a.WishListUpdatedBy)
                     .HasConstraintName("Fk_WishList_UpdatedBy")
                     .HasForeignKey(a => a.UpdatedBy)
                     .OnDelete(deleteBehavior: DeleteBehavior.NoAction);



                entity.HasOne(a => a.Deleter)
                   .WithMany(a => a.WishListDeletedBy)
                   .HasConstraintName("Fk_WishList_DeletedBy")
                   .HasForeignKey(a => a.DeletedBy)
                   .OnDelete(deleteBehavior: DeleteBehavior.NoAction);


            });
        }
    }
}
