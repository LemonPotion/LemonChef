using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Unit.Data;

namespace Tests.Unit.IngredientTests.Entity;

public class IngredientEntityNegativeTests
{
    [Fact]
    public void Ingredient_Constructor_Should_ValidateFail_When_InvalidData()
    {
        var ingredient = TestDataInvalidGenerator.GetIngredientInvalid();

        FluentActions.Invoking(() => new Ingredient(
                ingredient.Id,
                ingredient.Name,
                ingredient.Quantity,
                ingredient.Unit,
                ingredient.RecipeId))
            .Should()
            .Throw<ValidationException>();
    }
}