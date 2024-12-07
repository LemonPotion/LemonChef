using System.Linq.Expressions;
using Application.Dto_s.Ingredient.Responses;
using Application.Dto_s.Recipe.Requests;
using Application.Dto_s.Recipe.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeService
{
    Task<RecipeCreateResponse> AddAsync(RecipeCreateRequest request, CancellationToken cancellationToken = default);

    Task<RecipeGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<RecipeGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<Recipe, bool>> filter, CancellationToken cancellationToken = default);

    RecipeUpdateResponse Update(RecipeUpdateRequest request);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<RecipeGetResponse>> GetAllByUserIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<IngredientGetResponse>> GetRecipeIngredientsByRecipeId(Guid recipeId, CancellationToken cancellationToken = default);
}