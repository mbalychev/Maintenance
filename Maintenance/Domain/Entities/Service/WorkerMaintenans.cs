using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Maintenance.Entities
{
    public class WorkerMaintenans
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MaintenancePlanId { get; set; }
        [Required]
        public int WorkerId { get; set; }
    }
}
