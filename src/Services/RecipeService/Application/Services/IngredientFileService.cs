using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.IngredientFile.Requests;
using Application.Dto_s.LemonChefFile.IngredientFile.Response;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class IngredientFileService : IIngredientFileService
{
    private readonly IRepository<IngredientFile> _repository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public IngredientFileService(IRepository<IngredientFile> repository, IMapper mapper, IFileService fileService)
    {
        _repository = repository;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<IngredientFileCreateResponse> AddAsync(IngredientFileCreateRequest request, CancellationToken cancellationToken = default)
    {
        var ingredientFile = _mapper.Map<IngredientFile>(request);

        var googleDriveId = await _fileService.UploadFileAsync(request.FileData, cancellationToken);

        await request.FileData.Stream.DisposeAsync();

        ingredientFile.GoogleDriveName = googleDriveId;
        var createdIngredientFile = await _repository.AddAsync(ingredientFile, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<IngredientFileCreateResponse>(createdIngredientFile);
    }

    public async Task<IngredientFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ingredientFile = await _repository.GetByIdAsync(id, cancellationToken);

        if (ingredientFile is null)
            return null;
        
        var fileData = await _fileService.DownloadFileAsync(ingredientFile.GoogleDriveName, ingredientFile.OriginalName, cancellationToken);

        var response = _mapper.Map<IngredientFileGetResponse>(ingredientFile);

        response = response with { FileData = fileData };

        return response;
    }

    public async Task<List<IngredientFileGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<IngredientFile, bool>> filter, CancellationToken cancellationToken = default)
    {
        var ingredientFiles = await _repository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<IngredientFileGetResponse>>(ingredientFiles);
    }

    public IngredientFileUpdateResponse Update(IngredientFileUpdateRequest request)
    {
        var ingredientFileToUpdate = _mapper.Map<IngredientFile>(request);

        var updatedIngredientFile = _repository.Update(ingredientFileToUpdate);

        _repository.SaveChanges();

        return _mapper.Map<IngredientFileUpdateResponse>(updatedIngredientFile);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ingredientFile = await _repository.GetByIdAsync(id, cancellationToken);

        if (ingredientFile is null)
            return;
        
        await _repository.RemoveAsync(id, cancellationToken);
        
        await _fileService.DeleteFileAsync(ingredientFile.GoogleDriveName, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);
    }
}