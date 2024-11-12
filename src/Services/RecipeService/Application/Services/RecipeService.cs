using System.Linq.Expressions;
using Application.Dto_s.Ingredient.Responses;
using Application.Dto_s.Recipe.Requests;
using Application.Dto_s.Recipe.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
    }

    public async Task<RecipeCreateResponse> CreateAsync(RecipeCreateRequest request, Guid userId,
        CancellationToken cancellationToken)
    {
        var recipeEntity = _mapper.Map<Recipe>(request);

        recipeEntity.UserId = userId;

        var createdRecipe = await _recipeRepository.CreateAsync(recipeEntity, cancellationToken);
        return _mapper.Map<RecipeCreateResponse>(createdRecipe);
    }

    public async Task<RecipeGetResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<RecipeGetResponse>(recipe);
    }

    public async Task<List<RecipeGetResponse>> GetAllPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<Recipe, bool>> filter,
        CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetAllListPagedAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<RecipeGetResponse>>(recipes);
    }

    public async Task<RecipeUpdateResponse> UpdateAsync(RecipeUpdateRequest request, Guid userId,
        CancellationToken cancellationToken)
    {
        var recipeToUpdate = _mapper.Map<Recipe>(request);
        
        recipeToUpdate.UserId = userId;
        
        var updatedRecipe = await _recipeRepository.UpdateAsync(recipeToUpdate, cancellationToken);
        return _mapper.Map<RecipeUpdateResponse>(updatedRecipe);
    }


    public async Task<List<RecipeGetResponse>> GetAllByUserIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetAllByUserIdAsync(id, cancellationToken);
        return _mapper.Map<List<RecipeGetResponse>>(recipes);
    }

    public async Task<List<IngredientGetResponse>> GetRecipeIngredientsByRecipeId(Guid recipeId,
        CancellationToken cancellationToken)
    {
        var ingredients = await _recipeRepository.GetRecipeIngredientsByRecipeId(recipeId, cancellationToken);
        return _mapper.Map<List<IngredientGetResponse>>(ingredients);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await _recipeRepository.DeleteByIdAsync(id, cancellationToken);
    }
}