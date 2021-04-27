using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Maintenance.Entities
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "eMail")]
        public string Email { get; set; }
    }
}
