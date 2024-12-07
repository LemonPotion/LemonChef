using System.Linq.Expressions;
using Application.Dto_s.Ingredient.Requests;
using Application.Dto_s.Ingredient.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IIngredientService
{
    Task<IngredientCreateResponse> AddAsync(IngredientCreateRequest request, CancellationToken cancellationToken = default);

    Task<IngredientGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<IngredientGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<Ingredient, bool>> filter, CancellationToken cancellationToken = default);

    IngredientUpdateResponse Update(IngredientUpdateRequest request);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}