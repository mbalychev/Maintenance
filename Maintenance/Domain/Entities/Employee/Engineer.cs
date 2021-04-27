using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Entities
{
    public class Engineer : Worker
    {
        private string education = "не указано";

        [Display(Name = "Образование")]
        public string Education { get => education; set => education = value; }

    }
}
