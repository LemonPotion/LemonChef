using System.Linq.Expressions;
using Application.Dto_s.Ingredient.Requests;
using Application.Dto_s.Ingredient.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IIngredientService
{
    Task<IngredientCreateResponse> CreateAsync(IngredientCreateRequest request, CancellationToken cancellationToken);

    Task<IngredientGetResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<IngredientGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        Expression<Func<Ingredient, bool>> filter, CancellationToken cancellationToken);

    Task<IngredientUpdateResponse> UpdateAsync(IngredientUpdateRequest request, CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}