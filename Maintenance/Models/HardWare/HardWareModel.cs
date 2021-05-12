using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Entities;

namespace Maintenance.Models
{
    public class HardWareModel : HardWare
    {
        private string typeModel;
        public Manufacturer Manufacturer { get; set; }
        public static List<TypeHardWare> TypesRead => GetTypes();
        public string TypeModel { get => typeModel; }
        [Display(Name = "Кол-во ремонтов")]
        public int MaintenancePlansCount { get; set; }
        public List<MaintenancePlanModel> MaintenancesPlanModel { get;}
        [Display(Name = "Описание")]
        public string Description { get {
                switch (typeModel)
                {
                    case "FiscalRegistrator":
                        return "Фискальный регистратор";
                    case "Monitor":
                        return "Монитор";
                    case "Computer":
                        return "Системный блок";
                    default:
                        return "не определено";
                }
            } }
        public HardWareModel(Monitor monitor)
        {
            Id = monitor.Id;
            InstallationDate = monitor.InstallationDate;
            ManufacturerId = monitor.ManufacturerId;
            Name = monitor.Name;
            SerialNumber = monitor.SerialNumber;
            Manufacturer = monitor.Manufacturer;
            typeModel = "Monitor";
        }

        public HardWareModel(HardWare hard, string type, int maintenancePlansCount)
        {
            Id = hard.Id;
            InstallationDate = hard.InstallationDate;
            ManufacturerId = hard.ManufacturerId;
            Name = hard.Name;
            SerialNumber = hard.SerialNumber;
            Manufacturer = hard.Manufacturer;
            typeModel = type;
            MaintenancePlansCount = maintenancePlansCount;
        }

        public HardWareModel(FiscalRegistrator fiscalRegistrator)
        {
            Id = fiscalRegistrator.Id;
            InstallationDate = fiscalRegistrator.InstallationDate;
            ManufacturerId = fiscalRegistrator.ManufacturerId;
            Name = fiscalRegistrator.Name;
            SerialNumber = fiscalRegistrator.SerialNumber;
            Manufacturer = fiscalRegistrator.Manufacturer;
            typeModel = "FiscalRegistrator";
        }

        public HardWareModel(Computer computer)
        {
            Id = computer.Id;
            InstallationDate = computer.InstallationDate;
            ManufacturerId = computer.ManufacturerId;
            Name = computer.Name;
            SerialNumber = computer.SerialNumber;
            Manufacturer = computer.Manufacturer;
            typeModel = "Computer";
        }

        // HACK: изменить получение типа оборудования
        private static List<TypeHardWare> GetTypes()
        {
            List<TypeHardWare> typesHardWares = new List<TypeHardWare>();
            typesHardWares.AddRange(new TypeHardWare[] {
                new TypeHardWare { Type = "All", Description = "Все" },
                new TypeHardWare { Type = "Computer", Description = "Системные блоки" },
                new TypeHardWare { Type = "FiscalRegistrator", Description = "Фискальные регистраторы" },
                new TypeHardWare { Type = "Monitor", Description = "Мониторы" }
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
