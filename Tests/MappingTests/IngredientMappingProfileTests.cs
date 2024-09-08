using Application.Dto_s.Requests.Ingredient;
using Application.Dto_s.Responses.Ingredient;
using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using Domain.Validations.Primitives;
using FluentAssertions;

namespace Tests.MappingTests;

public class IngredientMappingProfileTests
{
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _configuration ;

    public IngredientMappingProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<IngredientMappingProfile>();
        });
        _configuration = config;
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Ingredient_MappingConfiguration_IsValid()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Fact]
    public void Should_Map_IngredientToIngredientCreateResponse()
    {
        var ingredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = null,
            Name = "Tomato",
            Quantity = null,
            RecipeId = Guid.NewGuid(),
            Unit = null
        };
        var response = _mapper.Map<IngredientCreateResponse>(ingredient);

        response.Should().BeEquivalentTo(ingredient, cfg => cfg
            .Excluding(src => src.CreatedOn)
            .Excluding(src => src.ModifiedOn)
            .Excluding(src=> src.Recipe)
            .ComparingByMembers<Ingredient>()
            .ComparingByMembers<IngredientCreateResponse>());
    }

    [Fact]
    public void Should_Map_IngredientCreateRequestToIngredient()
    {
        var request = new IngredientCreateRequest
        {
            Name = "Tomato",
            Quantity = null,
            RecipeId = Guid.NewGuid(),
            Unit = null
        };
        var response = _mapper.Map<Ingredient>(request);
        
        response.Should().BeEquivalentTo(request, cfg => cfg
            .ComparingByMembers<Ingredient>()
            .ComparingByMembers<IngredientCreateRequest>());
    }

    [Fact]
    public void Should_Map_IngredientToIngredientUpdateResponse()
    {
        var ingredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = null,
            Name = "Tomato",
            Quantity = null,
            RecipeId = Guid.NewGuid(),
            Unit = null
        };
        
        var response = _mapper.Map<IngredientUpdateResponse>(ingredient);

        response.Should().BeEquivalentTo(ingredient, cfg => cfg
            .Excluding(src=> src.CreatedOn)
            .Excluding(src=> src.ModifiedOn)
            .Excluding(src=> src.Recipe)
            .ComparingByMembers<Ingredient>()
            .ComparingByMembers<IngredientUpdateResponse>());
    }

    [Fact]
    public void Should_Map_IngredientUpdateRequestToIngredient()
    {
        var request = new IngredientUpdateRequest
        {
            Name = "Tomato",
            Quantity = null,
            RecipeId = Guid.NewGuid(),
            Unit = null,
            Id = Guid.NewGuid()
        };

        var response = _mapper.Map<Ingredient>(request);

        response.Should().BeEquivalentTo(request, cfg => cfg
            .ComparingByMembers<IngredientUpdateRequest>()
            .ComparingByMembers<Ingredient>());
    }

    [Fact]
    public void Should_Map_IngredientToIngredientGetResponse()
    {
        var ingredient = new Ingredient
        {
            Id = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = null,
            Name = "Tomato",
            Quantity = null,
            RecipeId = Guid.NewGuid(),
            Unit = null
        };

        var response = _mapper.Map<IngredientGetResponse>(ingredient);

        response.Should().BeEquivalentTo(ingredient, cfg => cfg
            .Excluding(src => src.CreatedOn)
            .Excluding(src => src.ModifiedOn)
            .Excluding(src => src.Recipe)
            .ComparingByMembers<Ingredient>()
            .ComparingByMembers<IngredientGetResponse>());
    }
}