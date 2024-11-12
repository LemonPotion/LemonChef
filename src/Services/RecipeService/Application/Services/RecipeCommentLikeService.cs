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

    public async Task<RecipeCommentLikeCreateResponse> CreateAsync(RecipeCommentLikeCreateRequest request, CancellationToken cancellationToken)
    {
        var recipeCommentLike = _mapper.Map<RecipeCommentLike>(request);
        var createdRecipeCommentLike = await _repository.CreateAsync(recipeCommentLike, cancellationToken);
        return _mapper.Map<RecipeCommentLikeCreateResponse>(createdRecipeCommentLike);
    }

    public async Task<RecipeCommentLikeGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipeCommentLike = await _repository.GetByIdAsync(id, cancellationToken);
        return recipeCommentLike == null ? null : _mapper.Map<RecipeCommentLikeGetResponse>(recipeCommentLike);
    }

    public async Task<List<RecipeCommentLikeGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize, Expression<Func<RecipeCommentLike, bool>> filter, CancellationToken cancellationToken)
    {
        var recipeCommentLikes = await _repository.GetAllListPagedAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<RecipeCommentLikeGetResponse>>(recipeCommentLikes);
    }

    public async Task<RecipeCommentLikeUpdateResponse> UpdateAsync(RecipeCommentLikeUpdateRequest request, CancellationToken cancellationToken)
    {
        var recipeCommentLikeToUpdate = _mapper.Map<RecipeCommentLike>(request);
        var updatedRecipeCommentLike = await _repository.UpdateAsync(recipeCommentLikeToUpdate, cancellationToken);
        return _mapper.Map<RecipeCommentLikeUpdateResponse>(updatedRecipeCommentLike);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    { 
        await _repository.DeleteByIdAsync(id, cancellationToken);
    }
}