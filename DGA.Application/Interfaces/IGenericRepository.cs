namespace DGA.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    void Update(T entity);
    Task<T?> Get(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<int> DeleteWhere<TResult>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}
    