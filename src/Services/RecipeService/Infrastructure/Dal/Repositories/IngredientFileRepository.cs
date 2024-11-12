using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class IngredientFileRepository : Repository<IngredientFile>, IRepository<IngredientFile>
{
    public IngredientFileRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}