using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maintenance.Entities
{
    [Table("Computers")]
    public class Computer : HardWare
    {
        [Required]
        public int SoftWareId { get; set; }
        public Software Software { get; set; }
    }
}
