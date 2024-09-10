using Application.Dto_s.Requests.Recipe;
using Application.Dto_s.Responses.Recipe;
using Application.Intrefaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class RecipeService : BaseService<Recipe,RecipeCreateRequest, RecipeUpdateRequest, RecipeGetResponse, RecipeCreateResponse, RecipeUpdateResponse>
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
        var entity = await _recipeRepository.GetAllByTelegramIdAsync(id, cancellationToken);
        return _mapper.Map<List<RecipeGetResponse>>(entity);
    }
}