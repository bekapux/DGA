namespace DGA.Infrastructure.Repositories;

public class GenericRepository<T>(DgaDbContext context) : IGenericRepository<T> where T : class
{
    protected DgaDbContext Context { get; private set; } = context;

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Context
            .AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task<int> DeleteWhere<TResult>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>()
            .Where(predicate)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public virtual async Task<T?> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>()
            .FindAsync(id, cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public virtual void Update(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().AnyAsync(predicate, cancellationToken);
    }
}
