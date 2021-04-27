using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Maintenance.Entities
{
    public class HardWare
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "№ серийный")]
        public string SerialNumber { get; set; }
        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата установки")]

        public DateTime? InstallationDate { get; set; }
    }
}
