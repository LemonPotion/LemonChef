using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class IngredientRepository : Repository<Ingredient>, IRepository<Ingredient>
{
    public IngredientRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}