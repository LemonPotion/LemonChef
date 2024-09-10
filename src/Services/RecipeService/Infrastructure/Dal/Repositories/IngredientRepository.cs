using Application.Intrefaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class IngredientRepository :BaseRepository<Ingredient>, IIngredientRepository
{
    public IngredientRepository(RecipiesDbContext dbContext) : base(dbContext)
    {
    }
    
}