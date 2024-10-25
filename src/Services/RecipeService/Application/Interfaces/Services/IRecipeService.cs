using Application.Dto_s.Ingredient.Responses;
using Application.Dto_s.Recipe.Requests;
using Application.Dto_s.Recipe.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeService : IBaseService<
    Recipe,
    RecipeCreateRequest,
    RecipeUpdateRequest,
    RecipeGetResponse,
    RecipeCreateResponse,
    RecipeUpdateResponse>
{
    public Task<List<RecipeGetResponse>> GetAllByUserIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<List<IngredientGetResponse>> GetRecipeIngredientsByRecipeId(Guid recipeId,
        CancellationToken cancellationToken);
}