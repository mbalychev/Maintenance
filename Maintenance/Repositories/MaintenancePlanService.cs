using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Services;
using Maintenance.Models;
using Maintenance.Entities;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maintenance.Repositories
{
    public class MaintenancePlanService : IServices<MaintenancePlanModel>
    {
        private readonly Context db;
        public MaintenancePlanService(Context context)
        {
            db = context;
        }

        public Task CreateAsync(MaintenancePlanModel item)
        {
            throw new NotImplementedException("не поддерживается в демо версии");
        }

        public Task DeleteAsync(int id)
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public async Task<List<MaintenancePlanModel>> ReadAllAsync(int idHardWare)
        {
            try
            {
                List<MaintenancePlan> maintenancePlans = await db.MaintenancePlans.Where(x => x.HardWareId == idHardWare).ToListAsync();
                List<MaintenancePlanModel> models = new List<MaintenancePlanModel>();
                    foreach (MaintenancePlan plan in maintenancePlans)
                    {
                        MaintenancePlanModel model = await GetMaintenancePlanModelAsync(plan);
                        models.Add(model);
                    }

                return models;
            }
            catch (Exception ex)
            {
                throw new Exception("ошибка при получении данных о плане обслуживания: " + ex.Message);
            }
        }

        private async Task<MaintenancePlanModel> GetMaintenancePlanModelAsync(MaintenancePlan maintenancePlan)
        {

            ServiceType serviceType;
            List<WorkerMaintenans> workerMaintenans;
            EngineerModel engineer;
            List<EngineerModel> engineers = new List<EngineerModel>();
            MaintenancePlanModel model;
            try
            {
                serviceType = await db.ServiceTypes.Where(x => x.Id == maintenancePlan.ServiceTypeId).FirstOrDefaultAsync();
                workerMaintenans = await db.WorkerMaintenans.Where(x => x.MaintenancePlanId == maintenancePlan.Id).ToListAsync();
                foreach (WorkerMaintenans worker in workerMaintenans)
                {
                    engineer = new EngineerModel(await db.Engineers.FirstOrDefaultAsync(x => x.Id == worker.WorkerId));
                    engineers.Add(new EngineerModel(engineer));
                }
                model = new MaintenancePlanModel(maintenancePlan, serviceType, engineers);
            }
            catch (Exception ex)
            {
                throw new Exception("ошибка при получении плана: " + ex.Message);
            }
            return model;
        }

        public async Task<MaintenancePlanModel> ReadAsync(int id)
        {
            MaintenancePlanModel model;
            try
            {
                MaintenancePlan maintenancePlan = await db.MaintenancePlans.FindAsync(id);
                model = await GetMaintenancePlanModelAsync(maintenancePlan);
            }
            catch (Exception ex)
            {
                throw new Exception("ошибка при получении плана: " + ex.Message);
            }
            return model;
        }

        public Task UpdateAsync(MaintenancePlanModel item)
        {
            throw new NotSupportedException("не поддерживается в демо версии");
        }

        Task<List<MaintenancePlanModel>> IServices<MaintenancePlanModel>.ReadAllAsync()
        {
            throw new NotSupportedException("необходимо использовать метод с параметром");
        }
    }
}
