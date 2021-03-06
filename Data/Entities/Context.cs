using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    public class Context : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        //public DbSet<HardWare> HardWares { get; set; }
        //public DbSet<Computer> Computers { get; set; }
        //public DbSet<FiscalRegistrator> FiscalRegistrators { get; set; }
        //public DbSet<Monitor> Monitors { get; set; }
        //public DbSet<Manufacturer> Manufacturers { get; set; }
        //public DbSet<ManufacturerRus> ManufacturerRus { get; set; }
        //public DbSet<ServiceType> ServiceTypes { get; set; }
        //public DbSet<Maintenance> Maintenances { get; set; }
        //public DbSet<Software> Softwares { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ServiceCentr;Trusted_Connection=true;");
        }

    }
}
