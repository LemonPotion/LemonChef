using Application.Dto_s.Ingredient.Requests;
using Application.Dto_s.Ingredient.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class IngredientService : BaseService
<Ingredient,IngredientCreateRequest, IngredientUpdateRequest, IngredientGetResponse, IngredientCreateResponse, IngredientUpdateResponse>, 
    IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IRecipeRepository _recipeRepository;

    public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper,
        IRecipeRepository recipeRepository) : base(ingredientRepository, mapper)
    {
        _ingredientRepository = ingredientRepository;
        _recipeRepository = recipeRepository;
    }
}