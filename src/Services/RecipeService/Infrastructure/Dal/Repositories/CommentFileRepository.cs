using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class CommentFileRepository : BaseRepository<CommentFile>, ICommentFileRepository
{
    public CommentFileRepository(RecipesDbContext dbContext) : base(dbContext)
    {
        
    }
}