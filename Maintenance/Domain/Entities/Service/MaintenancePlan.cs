using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Entities
{
    public class MaintenancePlan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "дата обслуживания")]
        public DateTime ServiceDate { get; set; }
        [Required]
        public int ServiceTypeId { get; set; }
        [Required]
        public int HardWareId { get; set; }
        [Display(Name = "Неисправность/Производимые работы")]
        public string Comment { get; set; }
    }
}
