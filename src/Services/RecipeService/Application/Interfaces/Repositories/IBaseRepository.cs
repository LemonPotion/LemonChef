using System.Linq.Expressions;

namespace Application.Interfaces.Repositories;

public interface IBaseRepository<TEntity>
{
    public Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);

    public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<List<TEntity>> GetAllListPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
}