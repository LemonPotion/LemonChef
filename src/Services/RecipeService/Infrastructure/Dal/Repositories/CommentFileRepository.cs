using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class CommentFileRepository : Repository<CommentFile>, IRepository<CommentFile>
{
    public CommentFileRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}