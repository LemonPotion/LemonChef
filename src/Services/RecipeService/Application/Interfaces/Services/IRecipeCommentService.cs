using System.Linq.Expressions;
using Application.Dto_s.Comment.RecipeComment.Requests;
using Application.Dto_s.Comment.RecipeComment.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeCommentService
{
    Task<RecipeCommentCreateResponse> AddAsync(RecipeCommentCreateRequest request, CancellationToken cancellationToken = default);

    Task<RecipeCommentGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<RecipeCommentGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeComment, bool>> filter, CancellationToken cancellationToken = default);

    RecipeCommentUpdateResponse Update(RecipeCommentUpdateRequest request);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}