using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Domain.Entities.Base;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly RecipesDbContext _dbContext;

    public BaseRepository(RecipesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(entity, cancellationToken);
        await SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.FindAsync<TEntity>(id, cancellationToken);
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var existingEntity = await GetByIdAsync(entity.Id, cancellationToken);
        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        await SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        _dbContext.Remove(entity);
        await SaveChangesAsync();
        return true;
    }
    public virtual async Task<List<TEntity>> GetAllListPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken)
    { 
        return await _dbContext.Set<TEntity>().Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).Where(filter).ToListAsync(cancellationToken);
    }

    private async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}