using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class IngredientFileRepository : BaseRepository<IngredientFile>, IIngredientFileRepository
{
    public IngredientFileRepository(RecipesDbContext dbContext) : base(dbContext)
    {
        
    }
}