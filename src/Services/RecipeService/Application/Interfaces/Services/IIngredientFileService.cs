using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.IngredientFile.Requests;
using Application.Dto_s.LemonChefFile.IngredientFile.Response;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IIngredientFileService
{
    Task<IngredientFileCreateResponse> CreateAsync(IngredientFileCreateRequest request,
        CancellationToken cancellationToken);

    Task<IngredientFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<IngredientFileGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        Expression<Func<IngredientFile, bool>> filter, CancellationToken cancellationToken);

    Task<IngredientFileUpdateResponse> UpdateAsync(IngredientFileUpdateRequest request,
        CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}