using System;
using System.Collections.Generic;
using System.Text;

namespace BLogic.Interfaces
{
    public interface IServices<T> : IDisposable where T : class
    {
        void Create(T item);
        T Read(int id);
        IEnumerable<T> ReadAll();
        void Update(T item);
        void Delete (int id);
    }
}
