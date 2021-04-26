using Data.Entities;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context db { get; }
        private WorkerRepo workerRepo;
        public UnitOfWork()
        {
            db = new Context();
        }
        public IRepository<Worker> Workers
        {
            get
            {
                if (workerRepo == null)
                    workerRepo = new WorkerRepo(db);
                return workerRepo;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
