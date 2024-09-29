using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class IngredientRepository :BaseRepository<Ingredient>, IIngredientRepository
{
    public IngredientRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
    
}