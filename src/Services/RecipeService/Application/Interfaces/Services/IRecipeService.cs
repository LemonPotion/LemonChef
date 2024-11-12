using System.Linq.Expressions;
using Application.Dto_s.Ingredient.Responses;
using Application.Dto_s.Recipe.Requests;
using Application.Dto_s.Recipe.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeService
{
    Task<RecipeCreateResponse> CreateAsync(RecipeCreateRequest request, Guid userId,
        CancellationToken cancellationToken);

    Task<RecipeGetResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<RecipeGetResponse>> GetAllPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<Recipe, bool>> filter,
        CancellationToken cancellationToken);

    Task<RecipeUpdateResponse> UpdateAsync(RecipeUpdateRequest request, Guid userId, CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<RecipeGetResponse>> GetAllByUserIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<IngredientGetResponse>> GetRecipeIngredientsByRecipeId(
        Guid recipeId,
        CancellationToken cancellationToken);
}