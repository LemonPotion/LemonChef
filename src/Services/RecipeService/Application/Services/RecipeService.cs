using Application.Dto_s.Ingredient.Responses;
using Application.Dto_s.Recipe.Requests;
using Application.Dto_s.Recipe.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class RecipeService : BaseService<
    Recipe,
    RecipeCreateRequest,
    RecipeUpdateRequest,
    RecipeGetResponse,
    RecipeCreateResponse,
    RecipeUpdateResponse>, IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public RecipeService(  IRecipeRepository recipeRepository, IMapper mapper) : base(recipeRepository, mapper)
    {
        _recipeRepository = recipeRepository;
        _mapper = mapper;
    }
    
    public async Task<List<RecipeGetResponse>> GetAllByTelegramIdAsync(int id, CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetAllByTelegramIdAsync(id, cancellationToken);
        return _mapper.Map<List<RecipeGetResponse>>(recipes);
    }
    
    public async Task<List<RecipeGetResponse>> GetAllByUserIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetAllByUserIdAsync(id, cancellationToken);
        return _mapper.Map<List<RecipeGetResponse>>(recipes);
    }

    public async Task<List<IngredientGetResponse>> GetRecipeIngredientsByRecipeId(Guid recipeId, CancellationToken cancellationToken)
    {
        var ingredients = await _recipeRepository.GetRecipeIngredientsByRecipeId(recipeId,cancellationToken);
        return _mapper.Map<List<IngredientGetResponse>>(ingredients);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, Guid userId,CancellationToken cancellationToken)
    {
        if (userId == Guid.Empty)
            return false;
        var recipe = await _recipeRepository.GetByIdAsync(id, cancellationToken);
        if (recipe.UserId != userId)
            return false;
        
        return await base.DeleteByIdAsync(id, cancellationToken);
    }
}