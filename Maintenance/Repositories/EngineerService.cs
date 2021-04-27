using Data;
using Data.Entities;
using Maintenance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maintenance.Models.Employee;

namespace Maintenance.Repositories
{
    public class EngineerService : IServices<EngineerModel>, IDisposable
    {
        private readonly Context db;
        public EngineerService(Context context)
        {
            db = context;
        }
        public void Create (EngineerModel engineerModel)
        {
            if (engineerModel != null)
            {
                db.Workers.Add(engineerModel as Engineer);
                db.SaveChanges();
            }
        }

        public EngineerModel Read(int id)
        {
            Engineer worker = db.Workers.FirstOrDefault(x=>x.Id == id) as Engineer;
            EngineerModel engineer = worker as EngineerModel;
            return engineer;
        }

        public List<EngineerModel> ReadAll()
        {
            List<Engineer> engineers = db.Engineers.ToList();
            List<EngineerModel> model = new List<EngineerModel>();
            foreach (Engineer engineer in engineers)
                model.Add(new EngineerModel { Id = engineer.Id, BirthDay = engineer.BirthDay, Education = engineer.Education, FirstName = engineer.FirstName, LastName = engineer.LastName});
            return model;
        }

        public void Update(EngineerModel engineerModel)
        {
            //Engineer engineer = db.Engineers.FirstOrDefault(x=>x.Id == engineerModel.Id);
            if (engineerModel != null)
            {
                db.Workers.Update(engineerModel as Engineer);
                //engineer = engineerModel as Engineer;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Worker worker = db.Workers.FirstOrDefault(x=>x.Id == id);
            if (worker != null)
            {
                db.Workers.Remove(worker);
                db.SaveChanges();
            }
        }
    
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
