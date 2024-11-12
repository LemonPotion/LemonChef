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

    public async Task<RecipeCommentCreateResponse> CreateAsync(RecipeCommentCreateRequest request,
        CancellationToken cancellationToken)
    {
        var recipeComment = _mapper.Map<RecipeComment>(request);
        var createdRecipeComment = await _repository.CreateAsync(recipeComment, cancellationToken);
        return _mapper.Map<RecipeCommentCreateResponse>(createdRecipeComment);
    }

    public async Task<RecipeCommentGetResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipeComment = await _repository.GetByIdAsync(id, cancellationToken);
        return recipeComment == null ? null : _mapper.Map<RecipeCommentGetResponse>(recipeComment);
    }

    public async Task<List<RecipeCommentGetResponse>> GetAllPagedAsync(int pageNumber, int pageSize,
        Expression<Func<RecipeComment, bool>> filter, CancellationToken cancellationToken)
    {
        var recipeComments = await _repository.GetAllListPagedAsync(pageNumber, pageSize, filter, cancellationToken);
        return _mapper.Map<List<RecipeCommentGetResponse>>(recipeComments);
    }

    public async Task<RecipeCommentUpdateResponse> UpdateAsync(RecipeCommentUpdateRequest request,
        CancellationToken cancellationToken)
    {
        var recipeCommentToUpdate = _mapper.Map<RecipeComment>(request);
        var updatedRecipeComment = await _repository.UpdateAsync(recipeCommentToUpdate, cancellationToken);
        return _mapper.Map<RecipeCommentUpdateResponse>(updatedRecipeComment);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repository.DeleteByIdAsync(id, cancellationToken);
    }
}