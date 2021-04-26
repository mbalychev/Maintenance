using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Entities;

namespace Maintenance.Models.Employee
{
    public class EngineerModel : Engineer
    {
        [Display (Name =  "Ф.И.О.")]
        public string FullName => FirstName + " " + LastName;
    }
}
