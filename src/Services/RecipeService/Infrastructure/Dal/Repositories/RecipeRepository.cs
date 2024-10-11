using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    private readonly RecipesDbContext _dbContext;

    public RecipeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<Recipe> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Recipes.Include(x => x.Ingredients)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity;
    }

    public override async Task<List<Recipe>> GetAllListPagedAsync(int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        var list = await _dbContext.Recipes.Include(x => x.Ingredients)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
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

    public async Task<List<Ingredient>> GetRecipeIngredientsByRecipeId(Guid recipeId,
        CancellationToken cancellationToken)
    {
        var recipe = await GetByIdAsync(recipeId, cancellationToken);
        return recipe.Ingredients.ToList();
    }

    public async Task<List<Recipe>> GetAllByUserIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipes = await _dbContext.Recipes
            .Include(x => x.Ingredients)
            .Where(x => x.UserId == id)
            .ToListAsync(cancellationToken);

        return recipes;
    }
}