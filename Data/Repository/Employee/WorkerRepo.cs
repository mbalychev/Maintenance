using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Data.Repository
{
    public class WorkerRepo : IRepository<Worker>
    {
        private Context db;
        public WorkerRepo (Context context)
        {
            db = context;
        }
        public IEnumerable<Worker> ReadAll()
        {
            return db.Workers;
        }

        public void Create(Worker worker)
        {
            if (worker != null)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
            }
        }

        public Worker Read(int id)
        {
            Worker worker = db.Workers.Find(id);
            return worker;
        }

        public void Update (Worker worker)
        {
            Worker workerUp = null;
            if (worker != null)
                workerUp = db.Workers.Find(worker.Id);
            if (workerUp != null)
            {
                workerUp.FirstName = worker.FirstName;
                workerUp.LastName = worker.LastName;
                workerUp.BirthDay = worker.BirthDay;
                db.SaveChanges();
            }
        }
        
        public void Delete(int id)
        {
                Worker deleteWorker = db.Workers.Find(id);
                if (deleteWorker != null)
                    db.Workers.Remove(deleteWorker);
        }
    }
}
