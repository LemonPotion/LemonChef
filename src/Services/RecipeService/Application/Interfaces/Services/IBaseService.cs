﻿namespace Application.Interfaces.Services;

public interface IBaseService<
    TEntity,
    TCreateRequest,
    TUpdateRequest,
    TGetResponse,
    TCreateResponse,
    TUpdateResponse>
{
    public Task<TCreateResponse> CreateAsync(TCreateRequest request, CancellationToken cancellationToken);
    public Task<TGetResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<TGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    public Task<TUpdateResponse> UpdateAsync(TUpdateRequest request, CancellationToken cancellationToken);
    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}