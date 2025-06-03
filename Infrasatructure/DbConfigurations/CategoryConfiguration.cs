using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfigurations
{
    public static class CategoryConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");
             
                entity.Property(a => a.ArName).HasMaxLength(50);
                entity.Property(a => a.EnName).HasMaxLength(50).IsUnicode(false);
                entity.Property(a => a.ArDescription).HasMaxLength(250);
                entity.Property(a => a.EnDescription).HasMaxLength(250).IsUnicode(false);



                entity.HasOne(a => a.Creator)
                .WithMany(a => a.ProductCategoriesCreatedBy)
                .HasConstraintName("Fk_ProductCategory_CreateBy")
                .HasForeignKey(a => a.CreatedBy)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);


                entity.HasOne(a => a.Updater)
               .WithMany(a => a.ProductCategoriesUpdatedBy)
               .HasConstraintName("Fk_ProductCategories_UpdatedBy")
               .HasForeignKey(a => a.UpdatedBy)
               .OnDelete(deleteBehavior: DeleteBehavior.NoAction);



                entity.HasOne(a => a.Deleter)
               .WithMany(a => a.ProductCategoriesDeletedBy)
               .HasConstraintName("Fk_ProductCategories_DeletedBy")
               .HasForeignKey(a => a.DeletedBy)
               .OnDelete(deleteBehavior: DeleteBehavior.NoAction);





            });
        }
    }
}
