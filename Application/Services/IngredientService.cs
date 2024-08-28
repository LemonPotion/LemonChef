using Application.Dto_s.Requests;
using Application.Dto_s.Responses;
using Application.Intrefaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class IngredientService : BaseService<Ingredient, CreateIngredientRequest, UpdateIngredientRequest, GetIngredientResponse, CreateIngredientResponse, UpdateIngredientResponse>
{
    private readonly IIngredientRepository _repository;
    public IngredientService(IIngredientRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
    }
}