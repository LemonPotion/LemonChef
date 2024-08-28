using Application.Intrefaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(RecipiesDbContext dbContext) : base(dbContext)
    {
    }
}