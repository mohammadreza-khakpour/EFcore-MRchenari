using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class ApiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=RezaSuperMarket;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<GoodCategory> GoodCategories { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<GoodEntry> GoodEntries { get; set; }
        public DbSet<SalesFactor> SalesFactors { get; set; }

    }
}
