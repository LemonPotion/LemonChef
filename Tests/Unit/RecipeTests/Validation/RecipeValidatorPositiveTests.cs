using Bogus;
using Domain.Entities;
using Domain.Validations.Validators;
using FluentValidation.TestHelper;

namespace Tests.Unit.RecipeTests.Validation;

public class RecipeValidatorPositiveTests
{
    private readonly RecipeValidator _recipeValidator = new(nameof(Recipe));
    private readonly Faker _faker = new Faker();
    
    [Fact]
    public void Title_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = new Recipe
        {
            Title = _faker.Commerce.ProductName()
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.Title);
    }
    
    [Fact]
    public void Link_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = new Recipe
        {
            Link = _faker.Internet.Url()
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.Link);
    }
    
    [Fact]
    public void Description_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = new Recipe
        {
            Description = _faker.Lorem.Sentence()
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }
    
    [Fact]
    public void Servings_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = new Recipe
        {
            Servings = _faker.Random.Int(1)
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.Servings);
    }
    
    [Fact]
    public void PreparationTime_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = new Recipe
        {
            PreparationTime = _faker.Random.Int(1)
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.PreparationTime);
    }
    
    [Fact]
    public void TelegramUserId_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = new Recipe
        {
            TelegramUserId = _faker.Random.Int(1)
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.TelegramUserId);
    }
}