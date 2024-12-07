using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.CommentFile.Requests;
using Application.Dto_s.LemonChefFile.CommentFile.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface ICommentFileService
{
    Task<CommentFileCreateResponse> AddAsync(CommentFileCreateRequest request, CancellationToken cancellationToken = default);

    Task<CommentFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<CommentFileGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<CommentFile, bool>> filter, CancellationToken cancellationToken = default);

    CommentFileUpdateResponse Update(CommentFileUpdateRequest request);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}