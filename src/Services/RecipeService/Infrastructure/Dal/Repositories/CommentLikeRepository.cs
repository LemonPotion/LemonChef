using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class CommentLikeRepository : Repository<CommentLike>, IRepository<CommentLike>
{
    public CommentLikeRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}