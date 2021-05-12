using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maintenance.Entities;

namespace Maintenance.Models
{
    public class ComputerModel : Computer
    {
        public List<MaintenancePlanModel> MaintenancesPlanModel { get; }
        public ComputerModel(Computer computer)
        {
            this.Id = computer.Id;
            this.InstallationDate = computer.InstallationDate;
            this.ManufacturerId = computer.ManufacturerId;
            this.Manufacturer = computer.Manufacturer;
            this.Name = computer.Name;
            this.SerialNumber = computer.SerialNumber;
            this.Software = computer.Software;
            this.SoftWareId = computer.SoftWareId;
        }
        public ComputerModel(Computer computer, List<MaintenancePlanModel> maintenances)
        {
            this.Id = computer.Id;
            this.InstallationDate = computer.InstallationDate;
            this.ManufacturerId = computer.ManufacturerId;
            this.Manufacturer = computer.Manufacturer;
            this.Name = computer.Name;
            this.SerialNumber = computer.SerialNumber;
            this.Software = computer.Software;
            this.SoftWareId = computer.SoftWareId;
            MaintenancesPlanModel = maintenances;
        }
    }
}
