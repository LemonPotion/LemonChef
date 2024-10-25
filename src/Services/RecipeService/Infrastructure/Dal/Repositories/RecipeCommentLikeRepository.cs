using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeCommentLikeRepository : BaseRepository<RecipeCommentLike>, IRecipeCommentLikeRepository
{
    public RecipeCommentLikeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}