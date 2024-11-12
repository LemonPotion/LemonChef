using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.RecipeFile.Requests;
using Application.Dto_s.LemonChefFile.RecipeFile.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeFileService
{
    Task<RecipeFileCreateResponse> CreateAsync(RecipeFileCreateRequest request, CancellationToken cancellationToken);

    Task<RecipeFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<RecipeFileGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeFile, bool>> filter, CancellationToken cancellationToken);

    Task<RecipeFileUpdateResponse> UpdateAsync(RecipeFileUpdateRequest request, CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}