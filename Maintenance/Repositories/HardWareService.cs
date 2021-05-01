using Data.Entities;
using Maintenance.Entities;
using Maintenance.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Repositories
{
    public class HardWareService : IHardWaresService, IDisposable
    {
        private readonly Context db;
        public HardWareService(Context context)
        {
            db = context;
        }
        public Task CreateAsync(HardWareModel item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public async Task<List<HardWareModel>> ReadAllAsync()
        {
            List<HardWare> hardWares = await db.HardWares.Include(x=>x.Manufacturer).ToListAsync();
            List<HardWareModel> models = await Task.Run(() => HardWareList(hardWares));
            return models;
        }

        public Task<HardWareModel> ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(HardWareModel item)
        {
            throw new NotImplementedException();
        }

        private async Task<List<HardWareModel>> HardWareList(List<HardWare> hardWares)
        {
            List<HardWareModel> models = new List<HardWareModel>();
            Manufacturer manufacturer = null;
            try
            {
                foreach (HardWare hard in hardWares)
                {
                    models.Add(new HardWareModel(hard));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка чтения списка оборудования!");
            }
            return models;

        }

        public async Task<List<HardWareModel>> ReadMonitorsAsync()
        {
            List<HardWareModel> models = new List<HardWareModel>();
            List<Monitor> monitors = await db.Monitors.Include(x=>x.Manufacturer).ToListAsync();
            try
            {
                foreach (Monitor monitor in monitors)
                {
                    models.Add(new HardWareModel(monitor));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ошибка при создании списка" + ex.Message);
            }
            return models;
        }
    }
}
