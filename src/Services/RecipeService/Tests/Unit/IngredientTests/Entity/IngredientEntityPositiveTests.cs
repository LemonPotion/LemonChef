using Domain.Entities;
using FluentAssertions;
using Tests.Unit.Data;

namespace Tests.Unit.IngredientTests.Entity;

public class IngredientEntityPositiveTests
{
    [Fact]
    public void Ingredient_Constructor_Should_Initialize_Correctly()
    {
        var ingredient = TestDataValidGenerator.GetIngredientValid();

        var ingredientResponse = new Ingredient(
            ingredient.Id
            , ingredient.Name
            , ingredient.Quantity,
            ingredient.Unit,
            ingredient.RecipeId);

        ingredientResponse.Should()
            .BeEquivalentTo(ingredient, cfg => cfg
                .Excluding(src => src.CreatedOn)
                .Excluding(src => src.ModifiedOn));
    }

    [Fact]
    public void Ingredient_Constructor_Should_ValidateSuccessfully_When_ValidData()
    {
        var ingredient = TestDataValidGenerator.GetIngredientValid();

        FluentActions.Invoking(() => new Ingredient(
                ingredient.Id,
                ingredient.Name,
                ingredient.Quantity,
                ingredient.Unit,
                ingredient.RecipeId))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void Recipe_EmptyConstructor_Should_CreateObjectWithoutValidation()
    {
        var recipe = new Recipe();

        recipe.Should()
            .NotBeNull();
    }
}