using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Maintenance.Entities
{
    public class Computer : HardWare
    {
        [Required]
        public int SoftWareId { get; set; }
        public Software Software { get; set; }
    }
}
