using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Task10.Domain.Entities;

namespace Task10.Domain
{
    public class EntityRepository<T>: IEntityRepository<T> where T: EntityBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EntityRepository<T>> _logger;

        public EntityRepository(AppDbContext appDbContext, ILogger<EntityRepository<T>> logger)
        {
            _context = appDbContext;
            _logger = logger;
        }
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> GetLastCreatedAsync()
        {
            return await _context.Set<T>().OrderByDescending(e => e.CreatedAt).FirstOrDefaultAsync();
        }
    }
}
