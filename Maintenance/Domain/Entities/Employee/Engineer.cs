using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Models;

namespace Maintenance.Entities
{
    public class Engineer : Worker
    {
        private string education = "не указано";

        [Display(Name = "Образование")]
        public string Education { get => education; set => education = value; }
        public Engineer() { }
        public Engineer(EngineerModel model)
        {
            this.Id = model.Id;
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.education = model.education;
            this.BirthDay = model.BirthDay;
        }

    }
}
