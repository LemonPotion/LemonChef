using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.CommentFile.Requests;
using Application.Dto_s.LemonChefFile.CommentFile.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface ICommentFileService
{
    Task<CommentFileCreateResponse> CreateAsync(CommentFileCreateRequest request, CancellationToken cancellationToken);

    Task<CommentFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<CommentFileGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        Expression<Func<CommentFile, bool>> filter, CancellationToken cancellationToken);

    Task<CommentFileUpdateResponse> UpdateAsync(CommentFileUpdateRequest request, CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}