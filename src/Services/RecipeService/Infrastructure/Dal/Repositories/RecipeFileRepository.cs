using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeFileRepository : Repository<RecipeFile>, IRepository<RecipeFile>
{
    public RecipeFileRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}