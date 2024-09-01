using Application.Intrefaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    private readonly RecipiesDbContext _dbContext;
    public RecipeRepository(RecipiesDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<Recipe> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Recipes.Include(x=>x.Ingredients).FirstOrDefaultAsync(x => x.Id==  id, cancellationToken);
        return entity;
    }

    public override async Task<List<Recipe>> GetAllListAsync(CancellationToken cancellationToken)
    {
        var list = await _dbContext.Recipes.Include(x => x.Ingredients).ToListAsync(cancellationToken);
        return list;
    }

    public async Task<List<Recipe>> GetAllByTelegramIdAsync(int id, CancellationToken cancellationToken)
    {
        var recipes = await _dbContext.Recipes
            .Include(x => x.Ingredients)
            .Where(x => x.TelegramUserId == id)
            .ToListAsync(cancellationToken);

        return recipes;
    }
}