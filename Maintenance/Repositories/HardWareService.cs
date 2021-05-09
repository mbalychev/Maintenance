using Data.Entities;
using Maintenance.Entities;
using Maintenance.Models;
using Maintenance.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Repositories
{
    public class HardWareService : IDisposable, IHardWaresService<HardWareModel> // IHardWaresService
    {
        private readonly Context db;
        public HardWareService(Context context)
        {
            db = context;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                HardWare hardWare = await db.HardWares.FindAsync(id);
                db.HardWares.Remove(hardWare);
            }
            catch (Exception ex)
            {
                throw new Exception("ошибка при удалении: " + ex.Message);
            }
        }

        public async Task<HardWareModel> ReadAsync (int id)
        {
            HardWare hardWare = await db.HardWares.Include(x=>x.Manufacturer).FirstAsync(x => x.Id == id);
            int maintenaceCount;
            maintenaceCount = await db.MaintenancePlans.Where(x => x.HardWareId == id).CountAsync();
            HardWareModel model = new HardWareModel(hardWare, hardWare.GetType().Name, maintenaceCount);
            return model;
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

        private async Task<List<HardWareModel>> HardWareList(List<HardWare> hardWares)
        {
            List<HardWareModel> models = new List<HardWareModel>();
            int maintenaceCount;
            try
            {
                foreach (HardWare hard in hardWares)
                {
                    maintenaceCount = await db.MaintenancePlans.Where(x => x.HardWareId == hard.Id).CountAsync();
                    models.Add(new HardWareModel(hard, hard.GetType().Name, maintenaceCount));
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
            List<Monitor> monitors = await db.Monitors.Include(x => x.Manufacturer).ToListAsync();
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

        public async Task<List<HardWareModel>> ReadFiscalsAsync()
        {
            List<HardWareModel> models = new List<HardWareModel>();
            List<FiscalRegistrator> fiscals = await db.FiscalRegistrators.ToListAsync();
            try
            {
                foreach (FiscalRegistrator fiscal in fiscals)
                    models.Add(new HardWareModel(fiscal));
            }
            catch (Exception ex)
            {
                throw new Exception("ошибка при составлении списка ф.регистраторов: " + ex.Message);
            }
            return models;
        }

        public async Task<List<HardWareModel>> ReadComputersAsync()
        {
            List<HardWareModel> models = new List<HardWareModel>();
            List<Computer> computers = await db.Computers.Include(x => x.Manufacturer).ToListAsync();
            try
            {
                foreach (Computer computer in computers)
                    models.Add(new HardWareModel(computer));
            }
            catch (Exception ex)
            {
                throw new Exception("ошибка при составлении списка компьютеров: " + ex.Message);
            }

            return models;
        }
    }
}
