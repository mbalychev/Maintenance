using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Entities;
using System.ComponentModel.DataAnnotations;

namespace Maintenance.Models
{
    public class MaintenancePlanModel : MaintenancePlan
    {
        [Display(Name = "Тип сервиса")]
        public ServiceType ServiceType { get; }
        public List<EngineerModel> Engineers { get; }
        public MaintenancePlanModel(MaintenancePlan plan, ServiceType serviceType, List<EngineerModel> engineers)
        {
            Id = plan.Id;
            Comment = plan.Comment;
            HardWareId = plan.HardWareId;
            ServiceDate = plan.ServiceDate;
            ServiceTypeId = plan.ServiceTypeId;
            ServiceType = serviceType;
            Engineers = engineers;
        }

    }
}
