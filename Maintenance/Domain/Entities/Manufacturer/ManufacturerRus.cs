using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Entities
{
    public class ManufacturerRus : Manufacturer
    {
        [Display(Name = "телефон")]
        public string TelephoneNumber { get; set; }
    }
}
