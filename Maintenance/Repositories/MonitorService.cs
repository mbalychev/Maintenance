using Data.Entities;
using Maintenance.Entities;
using Maintenance.Models;
using Maintenance.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintenance.Repositories
{
    public class MonitorService : IServices<MonitorModel>, IDisposable
    {
        private Context db;

        public MonitorService(Context context)
        {
            this.db = context;
        }

        public async Task CreateAsync(MonitorModel model)
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public async Task<List<MonitorModel>> ReadAllAsync()
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }

        public async Task<MonitorModel> ReadAsync(int id)
        {
            try
            {
                Monitor monitor = await db.Monitors.FindAsync(id);
                List<MaintenancePlanModel> planModels = await new MaintenancePlanService(db).ReadMaintenancesPlanAsync(id);
                MonitorModel model = new MonitorModel(monitor, planModels);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception("не возмжожно получить модель монитора: " + ex.Message);
            }
        }

        public async Task UpdateAsync(MonitorModel model)
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }

        public Task<List<MonitorModel>> ReadAllAsync(int id)
        {
            throw new NotSupportedException("не используется метод с параметром");
        }
    }
}
