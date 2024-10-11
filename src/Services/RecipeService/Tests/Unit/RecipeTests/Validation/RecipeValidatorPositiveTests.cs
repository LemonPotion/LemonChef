using Bogus;
using Domain.Entities;
using Domain.Validations.Validators;
using FluentValidation.TestHelper;
using Tests.Unit.Data;

namespace Tests.Unit.RecipeTests.Validation;

public class RecipeValidatorPositiveTests
{
    private readonly RecipeValidator _recipeValidator = new(nameof(Recipe));
    private readonly Faker _faker = new Faker();

    [Fact]
    public void Title_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();

        var result = _recipeValidator.TestValidate(recipe);

        result.ShouldNotHaveValidationErrorFor(x => x.Title);
    }

    [Fact]
    public void Link_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();

        var result = _recipeValidator.TestValidate(recipe);

        result.ShouldNotHaveValidationErrorFor(x => x.Link);
    }

    [Fact]
    public void Description_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();

        var result = _recipeValidator.TestValidate(recipe);

        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }

    [Fact]
    public void Servings_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();

        var result = _recipeValidator.TestValidate(recipe);

        result.ShouldNotHaveValidationErrorFor(x => x.Servings);
    }

    [Fact]
    public void PreparationTime_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();

        var result = _recipeValidator.TestValidate(recipe);

        result.ShouldNotHaveValidationErrorFor(x => x.PreparationTime);
    }

    [Fact]
    public void TelegramUserId_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();

        var result = _recipeValidator.TestValidate(recipe);

        result.ShouldNotHaveValidationErrorFor(x => x.TelegramUserId);
    }
}