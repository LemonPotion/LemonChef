using System.Linq.Expressions;
using Application.Dto_s.Like.RecipeLike.Requests;
using Application.Dto_s.Like.RecipeLike.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class RecipeLikeService : IRecipeLikeService
{
    private readonly IRepository<RecipeLike> _repository;
    private readonly IMapper _mapper;

    public RecipeLikeService(IRepository<RecipeLike> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RecipeLikeCreateResponse> CreateAsync(RecipeLikeCreateRequest request, CancellationToken cancellationToken)
    {
        var recipeLike = _mapper.Map<RecipeLike>(request);
        var createdRecipeLike = await _repository.CreateAsync(recipeLike, cancellationToken);
        return _mapper.Map<RecipeLikeCreateResponse>(createdRecipeLike);
    }

    public async Task<RecipeLikeGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipeLike = await _repository.GetByIdAsync(id, cancellationToken);
        return recipeLike == null ? null : _mapper.Map<RecipeLikeGetResponse>(recipeLike);
    }

    public async Task<List<RecipeLikeGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize, Expression<Func<RecipeLike, bool>> filter, CancellationToken cancellationToken)
    {
        var recipeLikes = await _repository.GetAllListPagedAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<RecipeLikeGetResponse>>(recipeLikes);
    }

    public async Task<RecipeLikeUpdateResponse> UpdateAsync(RecipeLikeUpdateRequest request, CancellationToken cancellationToken)
    {
        var recipeLikeToUpdate = _mapper.Map<RecipeLike>(request);
        var updatedRecipeLike = await _repository.UpdateAsync(recipeLikeToUpdate, cancellationToken);
        return _mapper.Map<RecipeLikeUpdateResponse>(updatedRecipeLike);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    { 
        await _repository.DeleteByIdAsync(id, cancellationToken);
    }
}