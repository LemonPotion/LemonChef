using System.Linq.Expressions;
using Application.Dto_s.Like.RecipeLike.Requests;
using Application.Dto_s.Like.RecipeLike.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeLikeService
{
    Task<RecipeLikeCreateResponse> CreateAsync(RecipeLikeCreateRequest request, CancellationToken cancellationToken);

    Task<RecipeLikeGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<RecipeLikeGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeLike, bool>> filter, CancellationToken cancellationToken);

    Task<RecipeLikeUpdateResponse> UpdateAsync(RecipeLikeUpdateRequest request, CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}