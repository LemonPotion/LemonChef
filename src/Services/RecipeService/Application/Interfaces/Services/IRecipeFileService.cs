using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.RecipeFile.Requests;
using Application.Dto_s.LemonChefFile.RecipeFile.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IRecipeFileService
{
    Task<RecipeFileCreateResponse> AddAsync(RecipeFileCreateRequest request, CancellationToken cancellationToken = default);

    Task<RecipeFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<RecipeFileGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeFile, bool>> filter, CancellationToken cancellationToken = default);

    RecipeFileUpdateResponse Update(RecipeFileUpdateRequest request);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}