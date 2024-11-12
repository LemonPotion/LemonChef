using Application.Interfaces.Repositories;
using Domain.Entities.Base;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class LikeRepository : Repository<Like>, IRepository<Like>
{
    public LikeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}