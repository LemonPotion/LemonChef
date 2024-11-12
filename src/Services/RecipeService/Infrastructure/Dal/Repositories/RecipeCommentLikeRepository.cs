using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeCommentLikeRepository : Repository<RecipeCommentLike>, IRepository<RecipeCommentLike>
{
    public RecipeCommentLikeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}