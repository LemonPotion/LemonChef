using Application.Interfaces.Repositories;
using Domain.Entities.Base;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly RecipesDbContext _dbContext;

    public BaseRepository(RecipesDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.FindAsync<TEntity>(id, cancellationToken);
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var existingPerson = await GetByIdAsync(entity.Id, cancellationToken);
        _dbContext.Entry(existingPerson).CurrentValues.SetValues(entity);
        return entity;
    }

    public virtual async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        _dbContext.Remove(entity);
        return true;
    }

    public virtual async Task<List<TEntity>> GetAllListPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync(cancellationToken);
    }
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}