using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check24.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(params object[] keys);
        Task<List<T>> ListAll();
        Task<T?> GetById(params object[] keys);
    }
}
