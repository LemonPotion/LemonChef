using System.Linq.Expressions;
using Application.Dto_s.Like.RecipeCommentLike.Requests;
using Application.Dto_s.Like.RecipeCommentLike.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeCommentLikeService
{
    Task<RecipeCommentLikeCreateResponse> AddAsync(RecipeCommentLikeCreateRequest request,
        CancellationToken cancellationToken = default);

    Task<RecipeCommentLikeGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<RecipeCommentLikeGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeCommentLike, bool>> filter, CancellationToken cancellationToken = default);

    RecipeCommentLikeUpdateResponse Update(RecipeCommentLikeUpdateRequest request);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}