using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Maintenance.Entities
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="необходимо указать Имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "необходимо указать Фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="необходимо указать дату рождения")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; }
    }
}
