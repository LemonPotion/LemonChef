using System.Linq.Expressions;
using Application.Dto_s.Like.RecipeCommentLike.Requests;
using Application.Dto_s.Like.RecipeCommentLike.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeCommentLikeService
{
    Task<RecipeCommentLikeCreateResponse> CreateAsync(RecipeCommentLikeCreateRequest request, CancellationToken cancellationToken);

    Task<RecipeCommentLikeGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<RecipeCommentLikeGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeCommentLike, bool>> filter, CancellationToken cancellationToken);

    Task<RecipeCommentLikeUpdateResponse> UpdateAsync(RecipeCommentLikeUpdateRequest request, CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}