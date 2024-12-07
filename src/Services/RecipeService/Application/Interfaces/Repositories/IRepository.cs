using System.Linq.Expressions;

namespace Application.Interfaces.Repositories;

public interface IRepository<TEntity>
{
    public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public TEntity Update(TEntity entity);

    public Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<TEntity>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default);

    public void SaveChanges();
}