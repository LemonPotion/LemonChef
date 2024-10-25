using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeFileRepository : BaseRepository<RecipeFile>, IRecipeFileRepository
{
    public RecipeFileRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}