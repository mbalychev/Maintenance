using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Entities
{
    public class FiscalRegistrator : HardWare
    {
        [Display(Name = "год выпусука фиск.знака")]
        public int SealYear { get; set; }
        [Display(Name = "№ фиск.знака")]
        public int SealNumber { get; set; }
        [Display(Name = "Дата выпуска")]
        [DataType(DataType.Date)]
        public DateTime Release { get; set; }
    }
}
