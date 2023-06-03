using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
  public interface IGenericRepository<T> where T : BaseEntity
  {
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> GetByIdAsync(int id);

    Task<T> GetEntityWithSpec(ISpecification<T> spec);

    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);


    /*     Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity); */
  }
}