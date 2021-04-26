using System;
using System.Collections.Generic;
using System.Text;
using Maintenance.Entities;
using Microsoft.EntityFrameworkCore;
using Maintenance.Models.Employee;

namespace Data.Entities
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ServiceCentr;Trusted_Connection=true;");
        }
        //public DbSet<HardWare> HardWares { get; set; }
        //public DbSet<Computer> Computers { get; set; }
        //public DbSet<FiscalRegistrator> FiscalRegistrators { get; set; }
        //public DbSet<Monitor> Monitors { get; set; }
        //public DbSet<Manufacturer> Manufacturers { get; set; }
        //public DbSet<ManufacturerRus> ManufacturerRus { get; set; }
        //public DbSet<ServiceType> ServiceTypes { get; set; }
        //public DbSet<Maintenance> Maintenances { get; set; }
        //public DbSet<Software> Softwares { get; set; }


        public DbSet<Maintenance.Models.Employee.EngineerModel> EngineerModel { get; set; }

        //public DbSet<EngineerModel> EngineerModel { get; set; }

    }
}
