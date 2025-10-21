using eCommerceProject.Domain.Interfaces;
using eCommerceProject.Infrastructure.Data;
using eCommerceProject.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace eCommerceProject.Infrastructure.Repositories
{
    public class CRUDRepository<TEntity>(AppDbContext context) : ICRUD<TEntity> where TEntity : class
    {
        public async Task<int> CreateAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return await context.SaveChangesAsync();        
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id) ?? 
                throw new ItemNotFoundException($"{typeof(TEntity).Name} with id: {id} not found");
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var result = await context.Set<TEntity>().FindAsync(id);
            return result!;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await context.SaveChangesAsync();
        }
    }
}
