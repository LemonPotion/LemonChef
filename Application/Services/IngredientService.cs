using Application.Dto_s.Requests;
using Application.Dto_s.Responses;
using Application.Intrefaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class IngredientService : BaseService<Ingredient, IngredientCreateRequest, IngredientUpdateRequest, IngredientGetResponse, IngredientCreateResponse, IngredientUpdateResponse>
{
    private readonly IIngredientRepository _ingredientRepository;
    public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper, IRecipeRepository recipeRepository) : base(ingredientRepository, mapper)
    {
        _ingredientRepository = ingredientRepository;
    }
}