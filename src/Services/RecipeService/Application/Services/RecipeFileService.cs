using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.RecipeFile.Requests;
using Application.Dto_s.LemonChefFile.RecipeFile.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class RecipeFileService : IRecipeFileService
{
    private readonly IRepository<RecipeFile> _repository;
    private readonly IMapper _mapper;

    public RecipeFileService(IRepository<RecipeFile> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RecipeFileCreateResponse> CreateAsync(RecipeFileCreateRequest request, CancellationToken cancellationToken)
    {
        var recipeFile = _mapper.Map<RecipeFile>(request);
        var createdRecipeFile = await _repository.CreateAsync(recipeFile, cancellationToken);
        return _mapper.Map<RecipeFileCreateResponse>(createdRecipeFile);
    }

    public async Task<RecipeFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipeFile = await _repository.GetByIdAsync(id, cancellationToken);
        return recipeFile == null ? null : _mapper.Map<RecipeFileGetResponse>(recipeFile);
    }

    public async Task<List<RecipeFileGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize, Expression<Func<RecipeFile, bool>> filter, CancellationToken cancellationToken)
    {
        var recipeFiles = await _repository.GetAllListPagedAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<RecipeFileGetResponse>>(recipeFiles);
    }

    public async Task<RecipeFileUpdateResponse> UpdateAsync(RecipeFileUpdateRequest request, CancellationToken cancellationToken)
    {
        var recipeFileToUpdate = _mapper.Map<RecipeFile>(request);
        var updatedRecipeFile = await _repository.UpdateAsync(recipeFileToUpdate, cancellationToken);
        return _mapper.Map<RecipeFileUpdateResponse>(updatedRecipeFile);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    { 
        await _repository.DeleteByIdAsync(id, cancellationToken);
    }
}