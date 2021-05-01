using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Entities;

namespace Maintenance.Models
{
    public class HardWareModel : HardWare
    {
        public Manufacturer Manufacturer { get; set; }
        public static List<TypeHardWare> TypesRead => GetTypes();

        public HardWareModel (Monitor monitor)
        {
            Id = monitor.Id;
            InstallationDate = monitor.InstallationDate;
            ManufacturerId = monitor.ManufacturerId;
            Name = monitor.Name;
            SerialNumber = monitor.SerialNumber;
            Manufacturer = monitor.Manufacturer;
        }

        public HardWareModel (HardWare hard)
        {
            Id = hard.Id;
            InstallationDate = hard.InstallationDate;
            ManufacturerId = hard.ManufacturerId;
            Name = hard.Name;
            SerialNumber = hard.SerialNumber;
            Manufacturer = hard.Manufacturer;
        }

        private static List<TypeHardWare> GetTypes()
        {
            List<TypeHardWare> typesHardWares = new List<TypeHardWare>();
            typesHardWares.AddRange(new TypeHardWare[] { 
                new TypeHardWare { Type = "All", Description = "Все" },
                new TypeHardWare { Type = "Computer", Description = "Системный блок" },
                new TypeHardWare { Type = "FiscalRegistrator", Description = "Фискаьлный регистратор" },
                new TypeHardWare { Type = "Monitor", Description = "Монитор" }
                });

            return typesHardWares;
        }
        public struct TypeHardWare
        {
            public string Description { get; set; }
            public string Type { get; set; }
        }
    }

}
