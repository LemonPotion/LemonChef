using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeCommentRepository : BaseRepository<RecipeComment>, IRecipeCommentRepository
{
    public RecipeCommentRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}