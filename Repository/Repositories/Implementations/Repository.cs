using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            if(entity is null) throw new ArgumentNullException(nameof(entity));
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression != null ? await _entities.Where(expression).ToListAsync() : await _entities.ToListAsync();
        }

        public async Task<T> FindAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            return await _entities.FindAsync(id) ?? throw new NullReferenceException(nameof(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            if(id is null) throw new ArgumentNullException(nameof(id));
            T? entity = await _entities.FindAsync(id);
            if (entity is null) throw new NullReferenceException(nameof(id));
            entity.SoftDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if(entity is null) throw new ArgumentNullException(nameof(entity));
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
