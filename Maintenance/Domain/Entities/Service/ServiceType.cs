using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Entities
{ 
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Комплектующие")]
        public bool HardWare { get; set; }
        [Display(Name = "ОС")]
        public bool SoftWare { get; set; }
    }
}
