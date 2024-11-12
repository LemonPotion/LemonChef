using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeLikeRepository : Repository<RecipeLike>, IRepository<RecipeLike>
{
    public RecipeLikeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}