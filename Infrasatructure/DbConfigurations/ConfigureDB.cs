using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfigurations
{
    public static  class ConfigureDB
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            CartProductConfiguration.Configure(modelBuilder);
            CartConfiguration.Configure(modelBuilder);
            CategoryConfiguration.Configure(modelBuilder);
            OrderConfiguration.Configure(modelBuilder);
            OrderProductConfiguration.Configure(modelBuilder);
            ProductConfiguration.Configure(modelBuilder);
            UserConfiguration.Configure(modelBuilder);
            WishListConfiguration.Configure(modelBuilder);
        }
    }
}
