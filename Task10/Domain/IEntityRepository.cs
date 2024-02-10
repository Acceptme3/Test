using Task10.Domain.Entities;

namespace Task10.Domain
{
    public interface IEntityRepository <T> where T : EntityBase
    {
        T GetById(Guid guid);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<T> GetLastCreatedAsync();

    }
}
