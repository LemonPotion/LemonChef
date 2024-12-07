using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeLikeRepository : Repository<RecipeLike>, IRepository<RecipeLike>
{
    public RecipeLikeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<RecipeLike> AddAsync(RecipeLike entity, CancellationToken cancellationToken)
    {
        var result = await base.AddAsync(entity, cancellationToken);
        var recipe = await _dbContext.Recipes.FindAsync(new object?[] { entity.RecipeId }, cancellationToken: cancellationToken);
        if (recipe is not null)
            recipe.LikeCount++;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return result;
    }
}