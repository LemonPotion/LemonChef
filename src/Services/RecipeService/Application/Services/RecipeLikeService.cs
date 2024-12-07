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

    public async Task<RecipeLikeCreateResponse> AddAsync(RecipeLikeCreateRequest request,
        CancellationToken cancellationToken = default)
    {
        var recipeLike = _mapper.Map<RecipeLike>(request);
        var createdRecipeLike = await _repository.AddAsync(recipeLike, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<RecipeLikeCreateResponse>(createdRecipeLike);
    }

    public async Task<RecipeLikeGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipeLike = await _repository.GetByIdAsync(id, cancellationToken);
        return recipeLike is null ? null : _mapper.Map<RecipeLikeGetResponse>(recipeLike);
    }

    public async Task<List<RecipeLikeGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeLike, bool>> filter, CancellationToken cancellationToken = default)
    {
        var recipeLikes = await _repository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<RecipeLikeGetResponse>>(recipeLikes);
    }

    public RecipeLikeUpdateResponse Update(RecipeLikeUpdateRequest request)
    {
        var recipeLikeToUpdate = _mapper.Map<RecipeLike>(request);
        var updatedRecipeLike = _repository.Update(recipeLikeToUpdate);
        _repository.SaveChanges();
        return _mapper.Map<RecipeLikeUpdateResponse>(updatedRecipeLike);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _repository.RemoveAsync(id, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);
    }
}