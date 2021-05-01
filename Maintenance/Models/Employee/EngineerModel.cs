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
        [Display(Name = "участник")]
        public int CountMaintenance { get; set; }
    }
}
