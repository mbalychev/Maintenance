using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Repository;
using Data.Entities;

namespace BLogic
{
    public class BL : IDisposable
    {
        private IUnitOfWork db { get; }

        public BL()
        {
            db = new UnitOfWork();
        }

        public IEnumerable<Worker> GetWorkers()
        {
            List<Worker> res = new List<Worker>();
            foreach (var i in db.Workers.ReadAll())
            {
                res.Add(new Worker { Id = i.Id, FirstName = i.FirstName, LastName = i.LastName, BirthDay = i.BirthDay });
            }
            return res;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
