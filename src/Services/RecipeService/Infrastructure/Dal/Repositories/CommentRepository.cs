using Application.Interfaces.Repositories;
using Domain.Entities.Base;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}