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
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public CommentFileService(IRepository<CommentFile> repository, IMapper mapper, IFileService fileService)
    {
        _repository = repository;

        _mapper = mapper;

        _fileService = fileService;
    }

    public async Task<CommentFileCreateResponse> AddAsync(CommentFileCreateRequest request, CancellationToken cancellationToken = default)
    {
        var commentFile = _mapper.Map<CommentFile>(request);

        var googleDriveId = await _fileService.UploadFileAsync(request.FileData, cancellationToken);

        commentFile.GoogleDriveName = googleDriveId;

        await request.FileData.Stream.DisposeAsync();

        var createdCommentFile = await _repository.AddAsync(commentFile, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CommentFileCreateResponse>(createdCommentFile);
    }

    public async Task<CommentFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var commentFile = await _repository.GetByIdAsync(id, cancellationToken);

        if (commentFile is null) return null;
        
        var fileData = await _fileService.DownloadFileAsync(commentFile.GoogleDriveName,  commentFile.OriginalName, cancellationToken);

        var response = _mapper.Map<CommentFileGetResponse>(commentFile);

        response = response with { FileData = fileData };

        return response;

    }
    
    public async Task<List<CommentFileGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<CommentFile, bool>> filter, CancellationToken cancellationToken = default)
    {
        var commentFiles = await _repository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<CommentFileGetResponse>>(commentFiles);
    }

    public CommentFileUpdateResponse Update(CommentFileUpdateRequest request)
    {
        var commentFileToUpdate = _mapper.Map<CommentFile>(request);

        var updatedCommentFile = _repository.Update(commentFileToUpdate);

        _repository.SaveChanges();

        return _mapper.Map<CommentFileUpdateResponse>(updatedCommentFile);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var commentFile = await _repository.GetByIdAsync(id, cancellationToken);

        if (commentFile is null)
            return;
        
        await _fileService.DeleteFileAsync(commentFile.GoogleDriveName, cancellationToken);

        await _repository.RemoveAsync(id, cancellationToken);
        
        await _repository.SaveChangesAsync(cancellationToken);
    }
}