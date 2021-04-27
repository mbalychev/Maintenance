using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Maintenance.Entities
{
    public class Software
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Версия")]
        public string Version { get; set; }
    }
}
