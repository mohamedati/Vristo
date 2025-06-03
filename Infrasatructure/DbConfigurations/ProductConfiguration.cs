using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfigurations
{
    public static class ProductConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.Property(a=>a.UsersNotified).HasDefaultValue(false);
                entity.Property(a => a.ArName).HasMaxLength(50);
                entity.Property(a => a.EnName).HasMaxLength(50).IsUnicode(false);
                entity.Property(a=>a.ArDescription).HasMaxLength(250);
                entity.Property(a => a.EnDescription).HasMaxLength(250).IsUnicode(false);
                entity.Property(a=>a.ArTitle).HasMaxLength(50);
                entity.Property(a => a.EnTitle).HasMaxLength(50).IsUnicode(false);
                entity.HasOne(a => a.Category)
                  .WithMany(a => a.Product)
                  .HasConstraintName("Fk_Product_Category")
                  .HasForeignKey(a => a.CategoryID)
                  .OnDelete(deleteBehavior: DeleteBehavior.NoAction); ;


                entity.HasOne(a => a.Creator)
                .WithMany(a => a.ProductsCreatedBy)
                .HasConstraintName("Fk_Product_CreatedBy")
                .HasForeignKey(a => a.CreatedBy)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction)
                ;


                entity.HasOne(a => a.Updater)
               .WithMany(a => a.ProductsUpdatedBy)
               .HasConstraintName("Fk_Product_UpdatedBy")
               .HasForeignKey(a => a.UpdatedBy)
               .OnDelete(deleteBehavior: DeleteBehavior.NoAction);



                entity.HasOne(a => a.Deleter)
               .WithMany(a => a.ProductsDeletedBy)
               .HasConstraintName("Fk_Product_DeletedBy")
               .HasForeignKey(a => a.DeletedBy)
               .OnDelete(deleteBehavior: DeleteBehavior.NoAction);





            });
                        }
    }
}
