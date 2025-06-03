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




                entity.HasOne(a => a.Cart)
                   .WithOne(a => a.ApplicationUser)
                   .HasConstraintName("FK_Cart_User");
              






            });
        }

     
    }
}
