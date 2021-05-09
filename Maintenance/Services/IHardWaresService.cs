using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Models;

namespace Maintenance.Services
{
    public interface IHardWaresService<HardWareModel>
    {
        Task<List<HardWareModel>> ReadAllAsync();
        Task DeleteAsync(int id);
        Task<HardWareModel> ReadAsync(int id);

        Task<List<HardWareModel>> ReadFiscalsAsync();
        Task<List<HardWareModel>> ReadMonitorsAsync();
        Task<List<HardWareModel>> ReadComputersAsync();
    }
}
