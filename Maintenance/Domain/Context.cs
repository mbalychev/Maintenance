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
        public DbSet<HardWare> HardWares { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<FiscalRegistrator> FiscalRegistrators { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ManufacturerRus> ManufacturerRus { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<MaintenancePlan> MaintenancePlans { get; set; }
        public DbSet<Software> Softwares { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ServiceCentr;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Engineer>().HasData(new Engineer[]
            {
            new Engineer { Id =1, FirstName = "Олег", LastName = "Иванов", BirthDay = Convert.ToDateTime("02.03.1985")},
            new Engineer { Id =2, FirstName = "Иван", LastName = "Лебедев", BirthDay = Convert.ToDateTime("06.04.1984")},
            new Engineer { Id =3, FirstName = "Олег", LastName = "Петров", BirthDay = Convert.ToDateTime("22.12.1981")},
            new Engineer { Id =4, FirstName = "Семен", LastName = "Филимонов", BirthDay = Convert.ToDateTime("17.06.1982")}
            });
            modelBuilder.Entity<Computer>().HasData(new Computer[]
            {
                new Computer { Id =1, InstallationDate = Convert.ToDateTime("20.02.2018"), Name = "HP", ManufacturerId = 1, SerialNumber = "as465500", SoftWareId = 1},
                new Computer { Id =2, InstallationDate = Convert.ToDateTime("25.07.2019"), Name = "HP", ManufacturerId = 1, SerialNumber = "as000500", SoftWareId = 1},
                new Computer { Id =3, InstallationDate = Convert.ToDateTime("06.12.2020"), Name = "HP", ManufacturerId = 1, SerialNumber = "as002500", SoftWareId = 2},
                new Computer { Id =4, InstallationDate = Convert.ToDateTime("10.05.2020"), Name = "HP", ManufacturerId = 1, SerialNumber = "as055500", SoftWareId = 3},
                new Computer { Id =5, InstallationDate = Convert.ToDateTime("25.10.2019"), Name = "HP", ManufacturerId = 1, SerialNumber = "as890500", SoftWareId = 2},
                new Computer { Id =6, InstallationDate = Convert.ToDateTime("14.11.2019"), Name = "HP", ManufacturerId = 1, SerialNumber = "as001500", SoftWareId = 1},
                new Computer { Id =7, InstallationDate = Convert.ToDateTime("17.07.2019"), Name = "HP", ManufacturerId = 1, SerialNumber = "as144500", SoftWareId = 1},
                new Computer { Id =8, InstallationDate = Convert.ToDateTime("01.04.2018"), Name = "HP", ManufacturerId = 1, SerialNumber = "as405500", SoftWareId = 1}
            });
            modelBuilder.Entity<FiscalRegistrator>().HasData( new FiscalRegistrator[]
            {
                new FiscalRegistrator{ Id = 9, Name = "FR-02", InstallationDate = Convert.ToDateTime("01.04.2019"), ManufacturerId =2, Release = Convert.ToDateTime("01.04.2019"), SealNumber = 4568800, SealYear = 2019, SerialNumber = "00456"},
                new FiscalRegistrator{ Id = 10, Name = "FR-02", InstallationDate = Convert.ToDateTime("01.04.2019"), ManufacturerId =2, Release = Convert.ToDateTime("01.04.2019"), SealNumber = 4564400, SealYear = 2019, SerialNumber = "00452"},
                new FiscalRegistrator{ Id = 11, Name = "FR-02", InstallationDate = Convert.ToDateTime("01.06.2019"), ManufacturerId =2, Release = Convert.ToDateTime("01.04.2019"), SealNumber = 4008800, SealYear = 2019, SerialNumber = "00422"},
                new FiscalRegistrator{ Id = 12, Name = "FR-02", InstallationDate = Convert.ToDateTime("05.06.2019"), ManufacturerId =3, Release = Convert.ToDateTime("01.04.2019"), SealNumber = 4508800, SealYear = 2019, SerialNumber = "00455"},
                new FiscalRegistrator{ Id = 13, Name = "FR-02", InstallationDate = Convert.ToDateTime("03.09.2019"), ManufacturerId =3, Release = Convert.ToDateTime("01.04.2019"), SealNumber = 4569800, SealYear = 2019, SerialNumber = "00454"}
            });
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer[]
                {
                new Manufacturer { Id = 1, Name = "HP Development Company", Address = "Palo Alto, CA, United States", Email = "HP@gmail.com"},
                new Manufacturer { Id = 4, Name = "LG Company", Address = "Palo Alto, CA, United States", Email = "LG@gmail.com"}
                });
            modelBuilder.Entity<ManufacturerRus>().HasData(new ManufacturerRus[]
                {
                new ManufacturerRus { Id = 2, Name = "ООО \"фискал регистр\"", Address = "Россия, Москва ул.Лескова 13  608800", Email = "fascal@gmail.com"},
                new ManufacturerRus { Id = 3, Name = "ООО \"Кристал\"", Address = "Россия, Хабаровск ул.Иванова 13 68100", Email = "Cristal@gmail.com"}
                });
            modelBuilder.Entity<Software>().HasData(new Software[]
            {
                new Software { Id = 1, Name = "Windows 7", Version = "bld44668"},
                new Software { Id = 2, Name = "Ubuntu", Version = "20.10"},
                new Software { Id = 3, Name = "Linux Mint", Version = "20.04"}
            });
            modelBuilder.Entity<Monitor>().HasData(new Monitor[]
            {
                new Monitor { Id = 14, Name = "LG 1300", ManufacturerId = 4, SerialNumber = "005663", InstallationDate = Convert.ToDateTime("01.06.2019") },
                new Monitor { Id = 15, Name = "LG 1300", ManufacturerId = 4, SerialNumber = "005665", InstallationDate = Convert.ToDateTime("20.04.2019") },
                new Monitor { Id = 16, Name = "LG 1300", ManufacturerId = 4, SerialNumber = "005666", InstallationDate = Convert.ToDateTime("19.07.2019") },
                new Monitor { Id = 17, Name = "LG 1300", ManufacturerId = 4, SerialNumber = "005067", InstallationDate = Convert.ToDateTime("13.08.2019") },
                new Monitor { Id = 18, Name = "LG 1300", ManufacturerId = 4, SerialNumber = "005660", InstallationDate = Convert.ToDateTime("09.11.2019") },
                new Monitor { Id = 19, Name = "LG 1300", ManufacturerId = 4, SerialNumber = "005061", InstallationDate = Convert.ToDateTime("09.11.2019") },
                new Monitor { Id = 20, Name = "LG 1300", ManufacturerId = 4, SerialNumber = "005063", InstallationDate = Convert.ToDateTime("09.11.2019") }
            });
            modelBuilder.Entity<ServiceType>().HasData(new ServiceType[]
            {
                new ServiceType { Id =1, Name = "Ремонт системного блока (без замены комплектующих)", HardWare = true, SoftWare = false},
                new ServiceType { Id =2, Name = "Ремонт фильного регистратора", HardWare = true, SoftWare = false},
                new ServiceType { Id =3, Name = "Ремонт монитора", HardWare = true, SoftWare = false},
                new ServiceType { Id =4, Name = "Ремонт системного блока (с заменой комплектующих)", HardWare = true, SoftWare = false},
                new ServiceType { Id =5, Name = "Исправление ошибок системном уровне", HardWare = false, SoftWare = true},
                new ServiceType { Id =6, Name = "Переустановка системы", HardWare = false, SoftWare = true},
                new ServiceType { Id =7, Name = "Установка драйверов", HardWare = false, SoftWare = true}
            });
            modelBuilder.Entity<MaintenancePlan>().HasData(new MaintenancePlan[]
                {
                    new MaintenancePlan { Id = 1, HardWareId = 8, ServiceDate = Convert.ToDateTime("09.01.2020"), ServiceTypeId = 1, Comment = "чистка комплектующих от пыли"},
                    new MaintenancePlan { Id = 2, HardWareId = 8, ServiceDate = Convert.ToDateTime("09.12.2020"), ServiceTypeId = 4, Comment = "замена мат.платы"},
                    new MaintenancePlan { Id = 3, HardWareId = 4, ServiceDate = Convert.ToDateTime("20.08.2020"), ServiceTypeId = 4, Comment = "замена блока питания"},
                    new MaintenancePlan { Id = 4, HardWareId = 5, ServiceDate = Convert.ToDateTime("09.01.2020"), ServiceTypeId = 4, Comment = "замена жест.диска"},
                    new MaintenancePlan { Id = 5, HardWareId = 3, ServiceDate = Convert.ToDateTime("16.01.2020"), ServiceTypeId = 1, Comment = "чистка комплектующих от пыли"},
                    new MaintenancePlan { Id = 6, HardWareId = 1, ServiceDate = Convert.ToDateTime("10.06.2020"), ServiceTypeId = 1, Comment = "чистка комплектующих от пыли"},
                    new MaintenancePlan { Id = 7, HardWareId = 14, ServiceDate = Convert.ToDateTime("01.03.2020"), ServiceTypeId = 3, Comment = "замена ламп"},
                    new MaintenancePlan { Id = 8, HardWareId = 17, ServiceDate = Convert.ToDateTime("02.07.2020"), ServiceTypeId = 3, Comment = "ремонт кнопки питания"},
                    new MaintenancePlan { Id = 9, HardWareId = 19, ServiceDate = Convert.ToDateTime("01.07.2020"), ServiceTypeId = 3, Comment = "замена ламп"},
                    new MaintenancePlan { Id = 10, HardWareId = 19, ServiceDate = Convert.ToDateTime("11.02.2020"), ServiceTypeId = 3, Comment = "замена блока питания"},
                    new MaintenancePlan { Id = 12, HardWareId = 19, ServiceDate = Convert.ToDateTime("12.02.2020"), ServiceTypeId = 3, Comment = "ремонт кнопки питания"},
                    new MaintenancePlan { Id = 13, HardWareId = 5, ServiceDate = Convert.ToDateTime("18.08.2020"), ServiceTypeId = 6, Comment = "зависает при включении"},
                    new MaintenancePlan { Id = 14, HardWareId = 2, ServiceDate = Convert.ToDateTime("03.04.2020"), ServiceTypeId = 6, Comment = "перегружается постоянно"},
                    new MaintenancePlan { Id = 15, HardWareId = 4, ServiceDate = Convert.ToDateTime("07.06.2020"), ServiceTypeId = 6, Comment = "не запускаються программы"},
                });

            modelBuilder.Entity<WorkerMaintenans>().HasData(new WorkerMaintenans[]
                {
                    new WorkerMaintenans { Id = 1, MaintenancePlanId = 1, WorkerId = 1},
                    new WorkerMaintenans { Id = 2, MaintenancePlanId = 1, WorkerId = 3},
                    new WorkerMaintenans { Id = 3, MaintenancePlanId = 1, WorkerId = 4},
                    new WorkerMaintenans { Id = 4, MaintenancePlanId = 2, WorkerId = 1},
                    new WorkerMaintenans { Id = 5, MaintenancePlanId = 2, WorkerId = 4},
                    new WorkerMaintenans { Id = 6, MaintenancePlanId = 3, WorkerId = 2},
                    new WorkerMaintenans { Id = 7, MaintenancePlanId = 4, WorkerId = 3},
                    new WorkerMaintenans { Id = 8, MaintenancePlanId = 4, WorkerId = 2},
                    new WorkerMaintenans { Id = 9, MaintenancePlanId = 5, WorkerId = 1},
                    new WorkerMaintenans { Id = 10, MaintenancePlanId = 6, WorkerId = 1},
                    new WorkerMaintenans { Id = 11, MaintenancePlanId = 7, WorkerId = 4},
                    new WorkerMaintenans { Id = 12, MaintenancePlanId = 7, WorkerId = 1},
                    new WorkerMaintenans { Id = 13, MaintenancePlanId = 7, WorkerId = 3},
                    new WorkerMaintenans { Id = 14, MaintenancePlanId = 8, WorkerId = 2},
                    new WorkerMaintenans { Id = 15, MaintenancePlanId = 9, WorkerId = 2},
                    new WorkerMaintenans { Id = 16, MaintenancePlanId = 10, WorkerId = 1},
                    new WorkerMaintenans { Id = 17, MaintenancePlanId = 11, WorkerId = 3},
                    new WorkerMaintenans { Id = 18, MaintenancePlanId = 12, WorkerId = 3},
                    new WorkerMaintenans { Id = 19, MaintenancePlanId = 12, WorkerId = 1},
                    new WorkerMaintenans { Id = 20, MaintenancePlanId = 13, WorkerId = 1},
                    new WorkerMaintenans { Id = 21, MaintenancePlanId = 14, WorkerId = 2},
                    new WorkerMaintenans { Id = 22, MaintenancePlanId = 15, WorkerId = 4},
                    new WorkerMaintenans { Id = 23, MaintenancePlanId = 15, WorkerId = 2}
                });
        }
    }
}
