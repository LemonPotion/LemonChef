using Application.Dto_s.Ingredient.Requests;
using Application.Dto_s.Ingredient.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IIngredientService : IBaseService<
    Ingredient,
    IngredientCreateRequest,
    IngredientUpdateRequest,
    IngredientGetResponse,
    IngredientCreateResponse,
    IngredientUpdateResponse>
{
    public Task<bool> DeleteByIdAsync(Guid id, Guid userId, CancellationToken cancellationToken);
}