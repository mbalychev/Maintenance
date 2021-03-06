using Data;
using Data.Entities;
using Maintenance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maintenance.Models.Employee;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Maintenance.Models;
using Maintenance.Services;

namespace Maintenance.Repositories
{
    public class EngineerService : IServices<EngineerModel>, IDisposable
    {
        private readonly Context db;
        public EngineerService(Context context)
        {
            db = context;
        }
        public async Task CreateAsync (EngineerModel model)
        {
            if (model != null)
            {
                try
                {
                    await db.Workers.AddAsync(new Engineer(model));
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("ошибка при добавлении нового сотрудника: " + ex.Message);
                }
            }
        }

        public async Task<EngineerModel> ReadAsync(int id)
        {
            EngineerModel model = null;
            try
            {
                Engineer engineer = await db.Engineers.FindAsync(id);
                int countMaintenance = await db.WorkerMaintenans.Where(x => x.WorkerId == engineer.Id).CountAsync();
                model = new EngineerModel(engineer, countMaintenance);
                
                model.MaintenancePlans = new List<MaintenancePlanModel>();
                int[] plansIds =  await db.WorkerMaintenans.Where(x => x.WorkerId == id).Select(x=>x.MaintenancePlanId).ToArrayAsync();
                for (int i =0; i < plansIds.Length; i++)
                {
                    MaintenancePlan plan = await db.MaintenancePlans.Where(x => x.Id == plansIds[i]).FirstOrDefaultAsync();
                    if (plan != null)
                    {
                        ServiceType serviceType = await db.ServiceTypes.FindAsync(plan.ServiceTypeId);
                        MaintenancePlanModel maintenancePlanModel = new MaintenancePlanModel(plan, serviceType, null);
                        model.MaintenancePlans.Add(maintenancePlanModel);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("не найден сотрудник: " + id);
            }
            if (model != null)
                return model;
            else
                throw new Exception("сотруники не найден");
        }

        public async Task<List<EngineerModel>> ReadAllAsync()
        {
            List<Engineer> engineers = await db.Engineers.ToListAsync();
            List<EngineerModel> models = await Task.Run(() => EngineerModelsList(engineers)) ;
            return models;
        }

        public async Task UpdateAsync(EngineerModel model)
        {
            if (model != null)
            {
                try
                {
                    Engineer engineer = (new Engineer(model));
                    db.Workers.Update(engineer);
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format("ошибка при редактировании модели id - {0}: {1}",model.Id, ex.Message));
                }
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
                try
                {
                    Worker worker = await db.Workers.FindAsync(id);
                    db.Workers.Remove(worker);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format("ошибка при удалении модели: " + ex.Message));
                }
        }
    
        public void Dispose()
        {
            db.Dispose();
        }

        private List<EngineerModel> EngineerModelsList(List<Engineer> engineers)
        {
            List<EngineerModel> models = new List<EngineerModel>();
            try
            {
                int countMaintenance = 0;
                foreach (Engineer engineer in engineers)
                {
                    countMaintenance = db.WorkerMaintenans.Where(x => x.WorkerId == engineer.Id).Count();
                    models.Add(new EngineerModel(engineer, countMaintenance));

                }
            }
            catch (Exception ex)
            {
                throw new Exception("ошибка при чтении списка сотрудников - " + ex.Message);
            }
            return models;
        }

        public Task<List<EngineerModel>> ReadAllAsync(int id)
        {
            throw new NotSupportedException("не используется тетод с параметром");
        }
    }
}
