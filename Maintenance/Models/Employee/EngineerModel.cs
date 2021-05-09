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
        public EngineerModel(Engineer engineer)
        {
            if (engineer  != null)
            {
                this.Id = engineer.Id;
                this.FirstName = engineer.FirstName;
                this.LastName = engineer.LastName;
                this.BirthDay = engineer.BirthDay;
                this.Education = engineer.Education;
            }
        }

        [Display (Name =  "Ф.И.О.")]
        public string FullName => FirstName + " " + LastName;
        [Display(Name = "участник")]
        public int CountMaintenance { get; set; }
        //public EngineerModel(Engineer)
        //{
            
        //}
    }
}
