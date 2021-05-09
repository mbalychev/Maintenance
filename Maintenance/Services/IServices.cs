using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Services
{
    public interface IServices<T> : IDisposable where T : class
    {
        Task CreateAsync(T item);
        Task<T> ReadAsync(int id);
        Task<List<T>> ReadAllAsync();
        Task<List<T>> ReadAllAsync(int id);
        Task UpdateAsync(T item);
        Task DeleteAsync (int id);
    }
}
