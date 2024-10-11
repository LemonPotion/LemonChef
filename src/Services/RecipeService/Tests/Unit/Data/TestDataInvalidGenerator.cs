using Application.Dto_s.Ingredient.Requests;
using Application.Dto_s.Recipe.Requests;
using Bogus;
using Domain.Entities;
using Domain.Validations.Primitives;

namespace Tests.Unit.Data;

public static class TestDataInvalidGenerator
{
    private static readonly Faker Faker = new Faker();

    public static Recipe GetRecipeInvalid()
    {
        return new Recipe()
        {
            Id = Guid.Empty,
            CreatedOn = Faker.Date.Future(),
            ModifiedOn = Faker.Date.Future(2),
            Description = Faker.Lorem.Sentence(6000),
            Link = Faker.Lorem.Sentence(),
            PreparationTime = int.MinValue,
            Servings = int.MinValue,
            TelegramUserId = int.MinValue,
            Title = Faker.Lorem.Sentence(6000)
        };
    }

    public static RecipeCreateRequest GetRecipeCreateRequestValid()
    {
        return new RecipeCreateRequest()
        {
            Description = Faker.Lorem.Sentence(6000),
            Link = Faker.Lorem.Sentence(),
            PreparationTime = int.MinValue,
            Servings = int.MinValue,
            TelegramUserId = int.MinValue,
            Title = Faker.Lorem.Sentence(6000)
        };
    }

    public static RecipeUpdateRequest GetRecipeUpdateRequestValid()
    {
        return new RecipeUpdateRequest()
        {
            Id = Guid.Empty,
            Description = Faker.Lorem.Sentence(6000),
            Link = Faker.Lorem.Sentence(),
            PreparationTime = int.MinValue,
            Servings = int.MinValue,
            TelegramUserId = int.MinValue,
            Title = Faker.Lorem.Sentence(6000)
        };
    }

    public static Ingredient GetIngredientInvalid()
    {
        return new Ingredient()
        {
            Id = Guid.Empty,
            CreatedOn = Faker.Date.Future(),
            ModifiedOn = Faker.Date.Future(2),
            Name = Faker.Lorem.Sentence(6000),
            Quantity = int.MinValue,
            RecipeId = Guid.Empty,
            Unit = UnitsOfMeasure.Gram
        };
    }

    public static IngredientCreateRequest GetIngredientCreateRequestValid()
    {
        return new IngredientCreateRequest()
        {
            Name = Faker.Lorem.Sentence(6000),
            Quantity = int.MinValue,
            RecipeId = Guid.Empty,
            Unit = UnitsOfMeasure.Gram
        };
    }

    public static IngredientUpdateRequest GetIngredientUpdateRequestValid()
    {
        return new IngredientUpdateRequest()
        {
            Id = Guid.Empty,
            Name = Faker.Lorem.Sentence(6000),
            Quantity = int.MinValue,
            RecipeId = Guid.Empty,
            Unit = UnitsOfMeasure.Gram
        };
    }
}