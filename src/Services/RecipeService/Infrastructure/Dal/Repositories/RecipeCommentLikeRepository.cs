using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class RecipeCommentLikeRepository : Repository<RecipeCommentLike>, IRepository<RecipeCommentLike>
{
    public RecipeCommentLikeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
    
    public override async Task<RecipeCommentLike> AddAsync(RecipeCommentLike entity, CancellationToken cancellationToken)
    {
        var result =  await base.AddAsync(entity, cancellationToken);
        var comment = await _dbContext.Comments.FindAsync(new object?[] { entity.CommentId }, cancellationToken: cancellationToken);
        if (comment is not null)
            comment.LikeCount++;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return result;
    }
}