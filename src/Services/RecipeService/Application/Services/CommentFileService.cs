using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.CommentFile.Requests;
using Application.Dto_s.LemonChefFile.CommentFile.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class CommentFileService : ICommentFileService
{
    private readonly IRepository<CommentFile> _repository;
    private readonly IMapper _mapper;

    public CommentFileService(IRepository<CommentFile> repository, IMapper mapper)
    {
        _repository = repository;

        _mapper = mapper;
    }

    public async Task<CommentFileCreateResponse> CreateAsync(CommentFileCreateRequest request, CancellationToken cancellationToken)
    {
        var commentFile = _mapper.Map<CommentFile>(request);
        var createdCommentFile = await _repository.CreateAsync(commentFile, cancellationToken);
        return _mapper.Map<CommentFileCreateResponse>(createdCommentFile);
    }

    public async Task<CommentFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var commentFile = await _repository.GetByIdAsync(id, cancellationToken);
        return commentFile == null ? null : _mapper.Map<CommentFileGetResponse>(commentFile);
    }

    public async Task<List<CommentFileGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize, Expression<Func<CommentFile, bool>> filter, CancellationToken cancellationToken)
    {
        var commentFiles = await _repository.GetAllListPagedAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<CommentFileGetResponse>>(commentFiles);
    }

    public async Task<CommentFileUpdateResponse> UpdateAsync(CommentFileUpdateRequest request, CancellationToken cancellationToken)
    {
        var commentFileToUpdate = _mapper.Map<CommentFile>(request);
        var updatedCommentFile = await _repository.UpdateAsync(commentFileToUpdate, cancellationToken);
        return _mapper.Map<CommentFileUpdateResponse>(updatedCommentFile);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repository.DeleteByIdAsync(id, cancellationToken);
    }
}