using Application.Dto_s.Requests.Recipe;
using Application.Dto_s.Responses.Recipe;
using Application.Mapping;
using AutoMapper;
using Bogus;
using Domain.Entities;
using FluentAssertions;
using Tests.Unit.Data;

namespace Tests.Unit.RecipeTests.Mapping;

public class RecipeMappingProfilePositiveTests
{
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _mapperConfiguration ;
    private readonly Faker _faker = new Faker();
    
    public RecipeMappingProfilePositiveTests()
    {
        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<RecipeMappingProfile>());
        _mapperConfiguration = config;

        _mapper = config.CreateMapper();
    }
    
    [Fact]
    public void Recipe_MappingConfiguration_IsValid()
    {
        _mapperConfiguration.AssertConfigurationIsValid();
    }

    [Fact]
    public void Should_Map_RecipeToRecipeCreateResponse()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();
        
        var response = _mapper.Map<RecipeCreateResponse>(recipe);
        
        response.Should().BeEquivalentTo(recipe, cfg => cfg
            .Excluding(src=>src.CreatedOn)
            .Excluding(src=> src.ModifiedOn)
            .Excluding(src=> src.Ingredients)
            .ComparingByMembers<Recipe>()
            .ComparingByMembers<RecipeCreateResponse>());
    }
    
    [Fact]
    public void Should_Map_RecipeToRecipeGetResponse()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();
        
        var response = _mapper.Map<RecipeGetResponse>(recipe);
        
        response.Should().BeEquivalentTo(recipe, cfg => cfg
            .Excluding(src=>src.CreatedOn)
            .Excluding(src=> src.ModifiedOn)
            .Excluding(src=> src.Ingredients)
            .ComparingByMembers<Recipe>()
            .ComparingByMembers<RecipeGetResponse>());
    }

    [Fact]
    public void Should_Map_RecipeToRecipeUpdateResponse()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();

        var response = _mapper.Map<RecipeUpdateResponse>(recipe);
        
        response.Should().BeEquivalentTo(recipe, cfg => cfg
            .Excluding(src=>src.CreatedOn)
            .Excluding(src=> src.ModifiedOn)
            .Excluding(src=> src.Ingredients)
            .ComparingByMembers<Recipe>()
            .ComparingByMembers<RecipeUpdateResponse>());
    }

    [Fact]
    public void Should_Map_RecipeCreateRequestToRecipe()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();
        var request = new RecipeCreateRequest()
        {
            Title = recipe.Title,
            Description = recipe.Description,
            Link = recipe.Link,
            PreparationTime = recipe.PreparationTime,
            Servings = recipe.Servings,
            TelegramUserId = recipe.TelegramUserId
        };

        var response = _mapper.Map<Recipe>(request);
        
        response.Should().BeEquivalentTo(request, cfg => cfg
            .ComparingByMembers<Recipe>()
            .ComparingByMembers<RecipeCreateRequest>());
    }

    [Fact]
    public void Should_Map_RecipeUpdateRequestToRecipe()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();
        var request = new RecipeUpdateRequest()
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            Link = recipe.Link,
            PreparationTime = recipe.PreparationTime,
            Servings = recipe.Servings,
            TelegramUserId = recipe.TelegramUserId
        };

        var response = _mapper.Map<Recipe>(request);
        
        response.Should().BeEquivalentTo(request, cfg => cfg
            .ComparingByMembers<Recipe>()
            .ComparingByMembers<RecipeUpdateRequest>());
    }
}