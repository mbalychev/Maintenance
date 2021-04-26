using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Data.Repository
{
     public interface IUnitOfWork : IDisposable
    {
        IRepository<Worker> Workers { get; }
        void Save();
    }
}
