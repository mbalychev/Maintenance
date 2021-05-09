using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Entities;
using System.Linq;
using Data.Entities;

namespace Maintenance.Models
{
    public class EngineerModel : Engineer
    {
        [Display (Name =  "Ф.И.О.")]
        public string FullName => FirstName + " " + LastName;
        [Display(Name = "Кол-во проведенных ТО")]
        public int CountMaintenance { get; set; }
        public List<MaintenancePlanModel> MaintenancePlans { get; set; }
        public EngineerModel()
        {
        }
        public EngineerModel(Engineer engineer, int countMaintenance)
        {
            if (engineer != null)
            {
                this.Id = engineer.Id;
                this.FirstName = engineer.FirstName;
                this.LastName = engineer.LastName;
                this.BirthDay = engineer.BirthDay;
                this.Education = engineer.Education;
                this.CountMaintenance = countMaintenance;
            }
        }
    }
}
