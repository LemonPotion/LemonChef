using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class CommentLikeRepository : BaseRepository<CommentLike>, ICommentLikeRepository
{
    public CommentLikeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}