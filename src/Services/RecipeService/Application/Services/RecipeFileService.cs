using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.RecipeFile.Requests;
using Application.Dto_s.LemonChefFile.RecipeFile.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class RecipeFileService : IRecipeFileService
{
    private readonly IRepository<RecipeFile> _repository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public RecipeFileService(IRepository<RecipeFile> repository, IMapper mapper, IFileService fileService)
    {
        _repository = repository;
        _mapper = mapper;
        _fileService = fileService;
    }
    
    public async Task<RecipeFileCreateResponse> AddAsync(RecipeFileCreateRequest request,
        CancellationToken cancellationToken = default)
    {
        var recipeFile = _mapper.Map<RecipeFile>(request);

        var googleName = await _fileService.UploadFileAsync(request.FileData, cancellationToken);

        await request.FileData.Stream.DisposeAsync();

        recipeFile.GoogleDriveName = googleName;

        var createdIngredientFile = await _repository.AddAsync(recipeFile, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<RecipeFileCreateResponse>(createdIngredientFile);
    }

    public async Task<RecipeFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipeFile = await _repository.GetByIdAsync(id, cancellationToken);
        
        if (recipeFile is null)
            return null;

        var fileData = await _fileService.DownloadFileAsync(recipeFile.GoogleDriveName, recipeFile.OriginalName, cancellationToken);

        var response = _mapper.Map<RecipeFileGetResponse>(recipeFile);

        response = response with { FileData = fileData };

        return response;
    }

    public async Task<List<RecipeFileGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeFile, bool>> filter, CancellationToken cancellationToken = default)
    {
        var recipeFiles = await _repository.GetAsync(pageNumber, pageSize, filter, cancellationToken);

        return _mapper.Map<List<RecipeFileGetResponse>>(recipeFiles);
    }

    public RecipeFileUpdateResponse Update(RecipeFileUpdateRequest request)
    {
        var recipeFileToUpdate = _mapper.Map<RecipeFile>(request);

        var updatedRecipeFile = _repository.Update(recipeFileToUpdate);
        _repository.SaveChanges();

        return _mapper.Map<RecipeFileUpdateResponse>(updatedRecipeFile);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipeFile = await _repository.GetByIdAsync(id, cancellationToken);

        if (recipeFile is null)
            return;

        await _fileService.DeleteFileAsync(recipeFile.GoogleDriveName, cancellationToken);

        await _repository.RemoveAsync(id, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);
    }
}