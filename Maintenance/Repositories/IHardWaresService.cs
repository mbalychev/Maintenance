using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Models;

namespace Maintenance.Repositories
{
    public interface IHardWaresService : IServices<HardWareModel>
    {
        Task<List<HardWareModel>> ReadMonitorsAsync();
    }
}
