using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Maintenance.Entities;
using Maintenance.Models;
using Maintenance.Services;
using Microsoft.EntityFrameworkCore;

namespace Maintenance.Repositories
{
    public class FiscalRegistratorService : IServices<FiscalRegistratorModel>, IDisposable
    {
        private readonly Context db;
        public FiscalRegistratorService(Context context)
        {
            db = context;
        }

        public Task CreateAsync(FiscalRegistratorModel item)
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }

        public Task DeleteAsync(int id)
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Task<List<FiscalRegistratorModel>> ReadAllAsync()
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }

        public Task<List<FiscalRegistratorModel>> ReadAllAsync(int id)
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }

        public async Task<FiscalRegistratorModel> ReadAsync(int id)
        {
            try
            {
                FiscalRegistrator registrator = await db.FiscalRegistrators.Include(x => x.Manufacturer).FirstOrDefaultAsync(x => x.Id == id);
                FiscalRegistratorModel model = new FiscalRegistratorModel(registrator);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task UpdateAsync(FiscalRegistratorModel item)
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }
    }
}
