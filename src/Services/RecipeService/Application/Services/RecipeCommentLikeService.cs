using System.Linq.Expressions;
using Application.Dto_s.Like.RecipeCommentLike.Requests;
using Application.Dto_s.Like.RecipeCommentLike.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class RecipeCommentLikeService : IRecipeCommentLikeService
{
    private readonly IRepository<RecipeCommentLike> _repository;
    private readonly IMapper _mapper;

    public RecipeCommentLikeService(IRepository<RecipeCommentLike> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RecipeCommentLikeCreateResponse> AddAsync(RecipeCommentLikeCreateRequest request,
        CancellationToken cancellationToken = default)
    {
        var recipeCommentLike = _mapper.Map<RecipeCommentLike>(request);
        var createdRecipeCommentLike = await _repository.AddAsync(recipeCommentLike, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<RecipeCommentLikeCreateResponse>(createdRecipeCommentLike);
    }

    public async Task<RecipeCommentLikeGetResponse?> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var recipeCommentLike = await _repository.GetByIdAsync(id, cancellationToken);
        return recipeCommentLike is null ? null : _mapper.Map<RecipeCommentLikeGetResponse>(recipeCommentLike);
    }

    public async Task<List<RecipeCommentLikeGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeCommentLike, bool>> filter, CancellationToken cancellationToken = default)
    {
        var recipeCommentLikes =
            await _repository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<RecipeCommentLikeGetResponse>>(recipeCommentLikes);
    }

    public RecipeCommentLikeUpdateResponse Update(RecipeCommentLikeUpdateRequest request)
    {
        var recipeCommentLikeToUpdate = _mapper.Map<RecipeCommentLike>(request);
        var updatedRecipeCommentLike = _repository.Update(recipeCommentLikeToUpdate);
        _repository.SaveChanges();
        return _mapper.Map<RecipeCommentLikeUpdateResponse>(updatedRecipeCommentLike);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _repository.RemoveAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}