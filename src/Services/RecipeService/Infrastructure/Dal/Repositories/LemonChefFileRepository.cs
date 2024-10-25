using Application.Interfaces.Repositories;
using Domain.Entities.Base;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class LemonChefFileRepository : BaseRepository<LemonChefFile>, ILemonChefFileRepository
{
    public LemonChefFileRepository(RecipesDbContext dbContext) : base(dbContext)
    {
    }
}