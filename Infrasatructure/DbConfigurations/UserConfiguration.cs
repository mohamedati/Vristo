using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfigurations
{
    public static class UserConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {



                entity.Property(e => e.RefreshToken).IsRequired(false);

                entity.Property(e => e.RefreshTokenExpiredAt).IsRequired(false);

                entity.Property(e => e.CartID).IsRequired(false);
                entity.HasOne(a => a.Cart)
                   .WithOne(a => a.ApplicationUser)
                   .HasConstraintName("FK_Cart_User");


                entity.HasMany(a => a.Wishes)
                  .WithOne(a => a.User)
                  .HasConstraintName("FK_Wishes_User")
                  ;




            });
        }

     
    }
}
