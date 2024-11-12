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

    public async Task<IngredientCreateResponse> CreateAsync(IngredientCreateRequest request,
        CancellationToken cancellationToken)
    {
        var ingredient = _mapper.Map<Ingredient>(request);
        var createdIngredient = await _repository.CreateAsync(ingredient, cancellationToken);
        return _mapper.Map<IngredientCreateResponse>(createdIngredient);
    }

    public async Task<IngredientGetResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var ingredient = await _repository.GetByIdAsync(id, cancellationToken);
        if (ingredient == null)
        {
            return null;
        }

        return _mapper.Map<IngredientGetResponse>(ingredient);
    }

    public async Task<List<IngredientGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        Expression<Func<Ingredient, bool>> filter, CancellationToken cancellationToken)
    {
        var ingredients = await _repository.GetAllListPagedAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<IngredientGetResponse>>(ingredients);
    }

    public async Task<IngredientUpdateResponse> UpdateAsync(IngredientUpdateRequest request,
        CancellationToken cancellationToken)
    {
        var ingredientToUpdate = _mapper.Map<Ingredient>(request);
        var updatedIngredient = await _repository.UpdateAsync(ingredientToUpdate, cancellationToken);
        return _mapper.Map<IngredientUpdateResponse>(updatedIngredient);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repository.DeleteByIdAsync(id, cancellationToken);
    }
}