using Bogus;
using Domain.Entities;
using Domain.Validations.Primitives;
using Domain.Validations.Validators;
using FluentValidation.TestHelper;

namespace Tests.Unit.RecipeTests.Validation;

public class RecipeValidatorTests
{
    private readonly RecipeValidator _recipeValidator = new(nameof(Recipe));
    private readonly Faker _faker = new Faker();
    
    [Fact]
    public void Title_ShouldHaveNullMessageValidationErrors_WhenNull()
    {
        var recipe = new Recipe
        {
            Title = null
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(ExceptionMessages.NullException(nameof(Recipe.Title)));
    }
    
    [Fact]
    public void Title_ShouldHaveEmptyMessageValidationErrors_WhenEmpty()
    {
        var recipe = new Recipe
        {
            Title = string.Empty
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(ExceptionMessages.EmptyException(nameof(Recipe.Title)));
    }
    
    [Fact]
    public void Title_ShouldHaveInvalidFormatMessageValidationErrors_WhenInvalidLength()
    {
        var recipe = new Recipe
        {
            Title = _faker.Lorem.Letter(6000)
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Recipe.Title)));
    }
    
    [Fact]
    public void Link_ShouldHaveValidationErrors_WhenInvalid()
    {
        var recipe = new Recipe
        {
            Link = _faker.Lorem.Letter(1)
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Link)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Recipe.Link)));
    }
    
    [Fact]
    public void Description_ShouldHaveNullMessageValidationErrors_WhenNull()
    {
        var recipe = new Recipe
        {
            Description = null
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage(ExceptionMessages.NullException(nameof(Recipe.Description)));
    }
    
    [Fact]
    public void Description_ShouldHaveEmptyMessageValidationErrors_WhenEmpty()
    {
        var recipe = new Recipe
        {
            Description = string.Empty
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage(ExceptionMessages.EmptyException(nameof(Recipe.Description)));
    }
    
    [Fact]
    public void Description_ShouldHaveInvalidFormatMessageValidationErrors_WhenInvalidLength()
    {
        var recipe = new Recipe
        {
            Description = _faker.Lorem.Letter(6000)
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Recipe.Description)));
    }
    
    [Fact]
    public void Servings_ShouldHaveValidationErrors_WhenInvalid()
    {
        var recipe = new Recipe
        {
            Servings = _faker.Random.Int(max:0)
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Servings)
            .WithErrorMessage(ExceptionMessages.TooLowNumber(nameof(Recipe.Servings)));
    }
    
    [Fact]
    public void PreparationTime_ShouldHaveValidationErrors_WhenInvalid()
    {
        var recipe = new Recipe
        {
            PreparationTime = _faker.Random.Int(max:0)
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.PreparationTime)
            .WithErrorMessage(ExceptionMessages.TooLowNumber(nameof(Recipe.PreparationTime)));
    }
    
    [Fact]
    public void TelegramUserId_ShouldHaveValidationErrors_WhenInvalid()
    {
        var recipe = new Recipe
        {
            TelegramUserId = _faker.Random.Int(max:0)
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.TelegramUserId)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Recipe.TelegramUserId)));
    }
}