using Domain.Entities;

namespace Application.Intrefaces.Repositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    public Task<List<Recipe>> GetAllByTelegramIdAsync(int id, CancellationToken cancellationToken);
}