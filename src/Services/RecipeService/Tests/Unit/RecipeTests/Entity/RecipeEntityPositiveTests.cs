using Domain.Entities;
using FluentAssertions;
using Tests.Unit.Data;

namespace Tests.Unit.RecipeTests.Entity;

public class RecipeEntityPositiveTests
{
    [Fact]
    public void Recipe_Constructor_Should_Initialize_Correctly()
    {
        var recipe = TestDataValidGenerator.GetRecipeValid();

        var recipeResponse = new Recipe(
            recipe.Id,
            recipe.Title,
            recipe.Link,
            recipe.PreparationTime,
            recipe.Servings,
            recipe.Description,
            Guid.Empty
        );

        recipeResponse.Should()
            .BeEquivalentTo(recipe, cfg => cfg
                .Excluding(src => src.CreatedOn)
                .Excluding(src => src.ModifiedOn));
    }
}