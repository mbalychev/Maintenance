using Maintenance.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Entities;

namespace Maintenance.Models
{
    public class FiscalRegistratorModel : FiscalRegistrator
    {
        public FiscalRegistratorModel(FiscalRegistrator fiscalRegistrator)
        {
            this.Id = fiscalRegistrator.Id;
            this.InstallationDate = fiscalRegistrator.InstallationDate;
            this.ManufacturerId = fiscalRegistrator.ManufacturerId;
            this.Manufacturer = fiscalRegistrator.Manufacturer;
            this.Name = fiscalRegistrator.Name;
            this.SerialNumber = fiscalRegistrator.SerialNumber;
            this.SealNumber = fiscalRegistrator.SealNumber;
            this.SealYear = fiscalRegistrator.SealYear;
            this.Release = fiscalRegistrator.Release;
        }
    }
}
