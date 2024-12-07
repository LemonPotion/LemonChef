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
    private readonly IRecipeRepository _repository;
    private readonly IMapper _mapper;

    public RecipeService(IRecipeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RecipeCreateResponse> AddAsync(RecipeCreateRequest request,
        CancellationToken cancellationToken = default)
    {
        var recipeEntity = _mapper.Map<Recipe>(request);

        var createdRecipe = await _repository.AddAsync(recipeEntity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<RecipeCreateResponse>(createdRecipe);
    }

    public async Task<RecipeGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipe = await _repository.GetByIdAsync(id, cancellationToken);
        
        return recipe is null ? null : _mapper.Map<RecipeGetResponse>(recipe);
    }

    public async Task<List<RecipeGetResponse>> GetAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<Recipe, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        var recipes = await _repository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<RecipeGetResponse>>(recipes);
    }

    public RecipeUpdateResponse Update(RecipeUpdateRequest request)
    {
        var recipeToUpdate = _mapper.Map<Recipe>(request);

        var updatedRecipe = _repository.Update(recipeToUpdate);
        _repository.SaveChanges();
        return _mapper.Map<RecipeUpdateResponse>(updatedRecipe);
    }


    public async Task<List<RecipeGetResponse>> GetAllByUserIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var recipes = await _repository.GetAllByUserIdAsync(id, cancellationToken);
        return _mapper.Map<List<RecipeGetResponse>>(recipes);
    }

    public async Task<List<IngredientGetResponse>> GetRecipeIngredientsByRecipeId(Guid recipeId,
        CancellationToken cancellationToken = default)
    {
        var ingredients = await _repository.GetRecipeIngredientsByRecipeId(recipeId, cancellationToken);
        return _mapper.Map<List<IngredientGetResponse>>(ingredients);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _repository.RemoveAsync(id, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);
    }
}