using Check24.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check24.Db.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public readonly Check24Context _context;

        public Repository(Check24Context context)
        {
            _context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            var res = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public virtual async Task Delete(params object[] keys)
        {
            var entity = await GetById(keys);

            ArgumentNullException.ThrowIfNull(entity);

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T?> GetById(params object[] keys)
        {
            return await _context.Set<T>().FindAsync(keys);
        }

        public virtual async Task<List<T>> ListAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
