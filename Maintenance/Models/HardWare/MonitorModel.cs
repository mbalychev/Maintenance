using Maintenance.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Models
{
    public class MonitorModel : Monitor
    {
        public List<MaintenancePlanModel> MaintenancesPlanModel { get; }

        public MonitorModel (Monitor monitor)
        {
            if (monitor != null)
            {
                this.Id = monitor.Id;
                this.InstallationDate = monitor.InstallationDate;
                this.ManufacturerId = monitor.ManufacturerId;
                this.Manufacturer = monitor.Manufacturer;
                this.Name = monitor.Name;
                this.SerialNumber = monitor.SerialNumber;
            }
        }
        public MonitorModel(Monitor monitor, List<MaintenancePlanModel> maintenances)
        {
            if (monitor != null)
            {
                this.Id = monitor.Id;
                this.InstallationDate = monitor.InstallationDate;
                this.ManufacturerId = monitor.ManufacturerId;
                this.Manufacturer = monitor.Manufacturer;
                this.Name = monitor.Name;
                this.SerialNumber = monitor.SerialNumber;
                this.MaintenancesPlanModel = maintenances;
            }
        }

        public static Monitor GetMonitorEntity(MonitorModel model)
        {
            Monitor monitor = new Monitor { Id = model.Id, ManufacturerId = model.ManufacturerId, Name = model.Name, SerialNumber = model.SerialNumber, InstallationDate = model.InstallationDate };
            return monitor;
        }
        public static Monitor GetMonitorEntity(MonitorModel model, List<MaintenancePlanModel> maintenances) 
        {
            Monitor monitor = new Monitor { Id = model.Id, ManufacturerId = model.ManufacturerId, Name = model.Name, SerialNumber = model.SerialNumber, InstallationDate = model.InstallationDate,  };
            return monitor;
        }

    }
}
