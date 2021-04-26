using AutoMapper;
using BLogic.Entities;
using BLogic.Infrastructure;
using BLogic.Interfaces;
using Data;
using Data.Entities;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLogic.Services
{
    public class WorkerService : IServices<Worker>, IDisposable
    {
        IUnitOfWork db { get; }
        public WorkerService()
        {
            db = new UnitOfWork();
        }
        public void Create (Worker worker)
        {
            if (worker != null)
            {
                db.Workers.Create(new Worker
                {
                    FirstName = worker.FirstName,
                    LastName = worker.LastName,
                    BirthDay = worker.BirthDay
                });
                db.Save();
            }
        }

        public Worker Read(int id)
        {
            Worker worker = db.Workers.Read(id);
            if (worker == null)
                throw new ValidationException("не сотрудник найден", "");
            else
                return new Worker { Id = worker.Id, LastName = worker.LastName, FirstName = worker.FirstName, BirthDay = worker.BirthDay };
        }

        public IEnumerable<Worker> ReadAll()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Worker, WorkerBll>()).CreateMapper();
            //return mapper.Map<IEnumerable<WorkerBll>, List<WorkerBll>>(db.Workers.ReadAll());

            List<WorkerBll> result = new List<WorkerBll>();
            foreach (var w in db.Workers.ReadAll())
                result.Add(new Mapper.Map<WorkerBll>(w));

        }

        public void Update(Worker worker)
        {
            DAL.Worker workerDAL = db.Workers.Read(worker.Id);
            if (workerDAL != null)
            {
                workerDAL.FirstName = worker.FirstName;
                workerDAL.LastName = worker.LastName;
                workerDAL.BirthDay = worker.BirthDay;
                db.Save();
            }
            else
                throw new ValidationException("сотрудник не найден", "");
        }

        public void Delete(int id)
        {
            DAL.Worker workerDAL = db.Workers.Read(id);
           if (workerDAL != null)
            {
                db.Workers.Delete(workerDAL.Id);
                db.Save();
            }
            else
                throw new ValidationException("сотрудник не найден", "");
        }
    
        public void Dispose()
        {

        }
    }
}
