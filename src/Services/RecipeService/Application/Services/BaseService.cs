using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities.Base;

namespace Application.Services;

public abstract class BaseService<
    TEntity,
    TCreateRequest,
    TUpdateRequest,
    TGetResponse,
    TCreateResponse,
    TUpdateResponse>
    : IBaseService<
        TEntity,
        TCreateRequest,
        TUpdateRequest,
        TGetResponse,
        TCreateResponse,
        TUpdateResponse> where TEntity : BaseEntity
{
    private readonly IBaseRepository<TEntity> _baseRepository;
    private readonly IMapper _mapper;

    protected BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
    {
        _baseRepository = baseRepository;
        _mapper = mapper;
    }

    public virtual async Task<TCreateResponse> CreateAsync(TCreateRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(request);
        var createdEntity = await _baseRepository.CreateAsync(entity, cancellationToken);
        await _baseRepository.SaveChangesAsync();
        return _mapper.Map<TCreateResponse>(createdEntity);
    }

    public virtual async Task<TGetResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _baseRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<TGetResponse>(entity);
    }

    public virtual async Task<List<TGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        var entities = await _baseRepository.GetAllListPagedAsync(pageNumber, pageSize, cancellationToken);
        return _mapper.Map<List<TGetResponse>>(entities);
    }

    public virtual async Task<TUpdateResponse> UpdateAsync(TUpdateRequest request, CancellationToken cancellationToken)
    {
        var entityToUpdate = _mapper.Map<TEntity>(request);
        var updatedEntity = await _baseRepository.UpdateAsync(entityToUpdate, cancellationToken);
        await _baseRepository.SaveChangesAsync();
        return _mapper.Map<TUpdateResponse>(updatedEntity);
    }

    public virtual async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var isDeleted = await _baseRepository.DeleteByIdAsync(id, cancellationToken);
        await _baseRepository.SaveChangesAsync();
        return isDeleted;
    }
}