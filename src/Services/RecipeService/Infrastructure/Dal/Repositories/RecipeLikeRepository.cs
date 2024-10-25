using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeLikeRepository : BaseRepository<RecipeLike>, IRecipeLikeRepository
{
    public RecipeLikeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}