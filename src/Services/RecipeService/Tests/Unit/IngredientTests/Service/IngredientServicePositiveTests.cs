using Application.Dto_s.Responses.Ingredient;
using Application.Intrefaces.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Moq;
using Tests.Unit.Data;

namespace Tests.Unit.IngredientTests.Service;

public class IngredientServicePositiveTests
{
    private readonly Mock<IIngredientRepository> _ingredientRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly IngredientService _ingredientService;

    public IngredientServicePositiveTests()
    {
        _ingredientRepositoryMock = new Mock<IIngredientRepository>();
        _mapperMock = new Mock<IMapper>();
        _ingredientService = new IngredientService(_ingredientRepositoryMock.Object, _mapperMock.Object);
        
    }

    [Fact]
    public async Task CreateIngredient_Should_ReturnIngredientCreateResponse()
    {
        
    }
}