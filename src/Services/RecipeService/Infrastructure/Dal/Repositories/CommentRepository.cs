using Application.Interfaces.Repositories;
using Domain.Entities.Base;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class CommentRepository : Repository<Comment>, IRepository<Comment>
{
    public CommentRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}