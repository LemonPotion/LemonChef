using System.Linq.Expressions;
using Application.Dto_s.LemonChefFile.IngredientFile.Requests;
using Application.Dto_s.LemonChefFile.IngredientFile.Response;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IIngredientFileService
{
    Task<IngredientFileCreateResponse> AddAsync(IngredientFileCreateRequest request,
        CancellationToken cancellationToken = default);

    Task<IngredientFileGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<IngredientFileGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<IngredientFile, bool>> filter, CancellationToken cancellationToken = default);

    IngredientFileUpdateResponse Update(IngredientFileUpdateRequest request);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}