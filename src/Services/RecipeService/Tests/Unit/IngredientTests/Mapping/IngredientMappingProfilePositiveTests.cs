using Application.Dto_s.Ingredient.Requests;
using Application.Dto_s.Ingredient.Responses;
using Application.Mapping;
using AutoMapper;
using Bogus;
using Domain.Entities;
using FluentAssertions;
using Tests.Unit.Data;

namespace Tests.Unit.IngredientTests.Mapping;

public class IngredientMappingProfilePositiveTests
{
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _mapperConfiguration;
    private readonly Faker _faker = new Faker();

    public IngredientMappingProfilePositiveTests()
    {
        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<IngredientMappingProfile>());

        _mapperConfiguration = config;

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Ingredient_MappingConfiguration_IsValid()
    {
        _mapperConfiguration.AssertConfigurationIsValid();
    }

    [Fact]
    public void Should_Map_IngredientToIngredientCreateResponse()
    {
        var ingredient = TestDataValidGenerator.GetIngredientValid();

        var response = _mapper.Map<IngredientCreateResponse>(ingredient);

        response.Should()
            .BeEquivalentTo(ingredient, cfg => cfg
                .Excluding(src => src.CreatedOn)
                .Excluding(src => src.ModifiedOn)
                .Excluding(src => src.Recipe)
                .ComparingByMembers<Ingredient>()
                .ComparingByMembers<IngredientCreateResponse>());
    }

    [Fact]
    public void Should_Map_IngredientCreateRequestToIngredient()
    {
        var request = TestDataValidGenerator.GetIngredientCreateRequestValid();

        var response = _mapper.Map<Ingredient>(request);

        response.Should().BeEquivalentTo(request, cfg => cfg
            .ComparingByMembers<Ingredient>()
            .ComparingByMembers<IngredientCreateRequest>());
    }

    [Fact]
    public void Should_Map_IngredientToIngredientUpdateResponse()
    {
        var ingredient = TestDataValidGenerator.GetIngredientValid();

        var response = _mapper.Map<IngredientUpdateResponse>(ingredient);

        response.Should().BeEquivalentTo(ingredient, cfg => cfg
            .Excluding(src => src.CreatedOn)
            .Excluding(src => src.ModifiedOn)
            .Excluding(src => src.Recipe)
            .ComparingByMembers<Ingredient>()
            .ComparingByMembers<IngredientUpdateResponse>());
    }

    [Fact]
    public void Should_Map_IngredientUpdateRequestToIngredient()
    {
        var request = TestDataValidGenerator.GetIngredientUpdateRequestValid();

        var response = _mapper.Map<Ingredient>(request);

        response.Should().BeEquivalentTo(request, cfg => cfg
            .ComparingByMembers<IngredientUpdateRequest>()
            .ComparingByMembers<Ingredient>());
    }

    [Fact]
    public void Should_Map_IngredientToIngredientGetResponse()
    {
        var ingredient = TestDataValidGenerator.GetIngredientValid();

        var response = _mapper.Map<IngredientGetResponse>(ingredient);

        response.Should().BeEquivalentTo(ingredient, cfg => cfg
            .Excluding(src => src.CreatedOn)
            .Excluding(src => src.ModifiedOn)
            .Excluding(src => src.Recipe)
            .ComparingByMembers<Ingredient>()
            .ComparingByMembers<IngredientGetResponse>());
    }
}