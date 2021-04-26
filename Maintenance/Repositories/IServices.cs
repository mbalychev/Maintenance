using System;
using System.Collections.Generic;
using System.Text;

namespace Maintenance.Repositories
{
    public interface IServices<T> : IDisposable where T : class
    {
        void Create(T item);
        T Read(int id);
        List<T> ReadAll();
        void Update(T item);
        void Delete (int id);
    }
}
