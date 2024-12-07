using System.Linq.Expressions;
using Application.Dto_s.Like.RecipeLike.Requests;
using Application.Dto_s.Like.RecipeLike.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeLikeService
{
    Task<RecipeLikeCreateResponse> AddAsync(RecipeLikeCreateRequest request, CancellationToken cancellationToken = default);

    Task<RecipeLikeGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<RecipeLikeGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeLike, bool>> filter, CancellationToken cancellationToken = default);

    RecipeLikeUpdateResponse Update(RecipeLikeUpdateRequest request);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}