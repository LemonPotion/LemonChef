using System.Linq.Expressions;
using Application.Dto_s.Comment.RecipeComment.Requests;
using Application.Dto_s.Comment.RecipeComment.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class RecipeCommentService : IRecipeCommentService
{
    private readonly IRepository<RecipeComment> _repository;
    private readonly IMapper _mapper;

    public RecipeCommentService(IRepository<RecipeComment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RecipeCommentCreateResponse> AddAsync(RecipeCommentCreateRequest request,
        CancellationToken cancellationToken = default)
    {
        var recipeComment = _mapper.Map<RecipeComment>(request);
        var createdRecipeComment = await _repository.AddAsync(recipeComment, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<RecipeCommentCreateResponse>(createdRecipeComment);
    }

    public async Task<RecipeCommentGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var recipeComment = await _repository.GetByIdAsync(id, cancellationToken);
        
        return recipeComment is null ? null : _mapper.Map<RecipeCommentGetResponse>(recipeComment);
    }

    public async Task<List<RecipeCommentGetResponse>> GetAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeComment, bool>> filter, CancellationToken cancellationToken = default)
    {
        var recipeComments = await _repository.GetAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<RecipeCommentGetResponse>>(recipeComments);
    }

    public RecipeCommentUpdateResponse Update(RecipeCommentUpdateRequest request)
    {
        var recipeCommentToUpdate = _mapper.Map<RecipeComment>(request);
        var updatedRecipeComment = _repository.Update(recipeCommentToUpdate);
        _repository.SaveChanges();
        return _mapper.Map<RecipeCommentUpdateResponse>(updatedRecipeComment);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _repository.RemoveAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}