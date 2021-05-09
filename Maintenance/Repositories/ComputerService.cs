using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Models;
using Maintenance.Entities;
using Maintenance.Services;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maintenance.Repositories
{
    public class ComputerService : IServices<ComputerModel>, IDisposable
    {
        private readonly Context db;
        public ComputerService(Context context)
        {
            db = context;
        }
        public Task CreateAsync(ComputerModel item)
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

        public Task<List<ComputerModel>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ComputerModel>> ReadAllAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ComputerModel> ReadAsync(int id)
        {
            try
            {
                Computer computer = await db.Computers.Include(x=>x.Manufacturer).Include(x=>x.Software).FirstOrDefaultAsync(x=>x.Id == id);
                ComputerModel model = new ComputerModel(computer);
                return model;
            }
            catch(Exception ex)
            {
                throw new Exception("монитор не найден: " + ex.Message);
            }
        }

        public Task UpdateAsync(ComputerModel item)
        {
            throw new NotSupportedException("функция не поддерживается в демо версии");
        }
    }
}
