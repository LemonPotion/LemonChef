using Application.Intrefaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeIngredientRepository : BaseRepository<RecipeIngredient>, IRecipeIngredientRepository
{
    public RecipeIngredientRepository(RecipiesDbContext dbContext) : base(dbContext)
    {
    }
}