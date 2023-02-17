using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitconverterData
{
    public class UnitconverterDataContext : DbContext
    {
        public UnitconverterDataContext(DbContextOptions<UnitconverterDataContext> options):
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Conversionrates> Conversionrates { get; set; }
    }
}
