using System.Linq.Expressions;
using Application.Dto_s.Comment.RecipeComment.Requests;
using Application.Dto_s.Comment.RecipeComment.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeCommentService
{
    Task<RecipeCommentCreateResponse> CreateAsync(RecipeCommentCreateRequest request, CancellationToken cancellationToken);

    Task<RecipeCommentGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<RecipeCommentGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeComment, bool>> filter, CancellationToken cancellationToken);

    Task<RecipeCommentUpdateResponse> UpdateAsync(RecipeCommentUpdateRequest request, CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}