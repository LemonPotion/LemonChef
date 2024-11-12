using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.IngredientFile.Requests;
using Application.Dto_s.LemonChefFile.IngredientFile.Response;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class IngredientFileService : IIngredientFileService
{
    private readonly IRepository<IngredientFile> _repository;
    private readonly IMapper _mapper;

    public IngredientFileService(IRepository<IngredientFile> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IngredientFileCreateResponse> CreateAsync(IngredientFileCreateRequest request, CancellationToken cancellationToken)
    {
        var ingredientFile = _mapper.Map<IngredientFile>(request);
        var createdIngredientFile = await _repository.CreateAsync(ingredientFile, cancellationToken);
        return _mapper.Map<IngredientFileCreateResponse>(createdIngredientFile);
    }

    public async Task<IngredientFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var ingredientFile = await _repository.GetByIdAsync(id, cancellationToken);
        return ingredientFile == null ? null : _mapper.Map<IngredientFileGetResponse>(ingredientFile);
    }

    public async Task<List<IngredientFileGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize, Expression<Func<IngredientFile, bool>> filter, CancellationToken cancellationToken)
    {
        var ingredientFiles = await _repository.GetAllListPagedAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<IngredientFileGetResponse>>(ingredientFiles);
    }

    public async Task<IngredientFileUpdateResponse> UpdateAsync(IngredientFileUpdateRequest request, CancellationToken cancellationToken)
    {
        var ingredientFileToUpdate = _mapper.Map<IngredientFile>(request);
        var updatedIngredientFile = await _repository.UpdateAsync(ingredientFileToUpdate, cancellationToken);
        return _mapper.Map<IngredientFileUpdateResponse>(updatedIngredientFile);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repository.DeleteByIdAsync(id, cancellationToken);
    }
}