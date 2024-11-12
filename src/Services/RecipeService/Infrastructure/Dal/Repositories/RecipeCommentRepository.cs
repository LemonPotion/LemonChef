using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeCommentRepository : Repository<RecipeComment>, IRepository<RecipeComment>
{
    public RecipeCommentRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}