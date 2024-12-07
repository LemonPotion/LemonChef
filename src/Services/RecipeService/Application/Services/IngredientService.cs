using System.Linq.Expressions;
using Application.Dto_s.Ingredient.Requests;
using Application.Dto_s.Ingredient.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class IngredientService : IIngredientService
{
    private readonly IRepository<Ingredient> _repository;
    private readonly IMapper _mapper;

    public IngredientService(IRepository<Ingredient> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IngredientCreateResponse> AddAsync(IngredientCreateRequest request, CancellationToken cancellationToken = default)
    {
        var ingredient = _mapper.Map<Ingredient>(request);
        var createdIngredient = await _repository.AddAsync(ingredient, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<IngredientCreateResponse>(createdIngredient);
    }

    public async Task<IngredientGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ingredient = await _repository.GetByIdAsync(id, cancellationToken);
        
        return ingredient is null ? null : _mapper.Map<IngredientGetResponse>(ingredient);
    }

    public async Task<List<IngredientGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<Ingredient, bool>> filter, CancellationToken cancellationToken = default)
    {
        var ingredients = await _repository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<IngredientGetResponse>>(ingredients);
    }

    public IngredientUpdateResponse Update(IngredientUpdateRequest request)
    {
        var ingredientToUpdate = _mapper.Map<Ingredient>(request);
        var updatedIngredient = _repository.Update(ingredientToUpdate);
        _repository.SaveChanges();
        return _mapper.Map<IngredientUpdateResponse>(updatedIngredient);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _repository.RemoveAsync(id, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);
    }
}