using Bogus;
using Domain.Entities;
using Domain.Validations.Primitives;

namespace Tests.Unit.Data;

public static class TestDataValidGenerator
{
    private static readonly Faker Faker = new Faker();
    
    public static Recipe GetRecipeValid()
    {
        return new Recipe()
        {
            Id = Faker.Random.Guid(),
            CreatedOn = Faker.Date.Past(),
            ModifiedOn = Faker.Date.Recent(),
            Description = Faker.Lorem.Sentence(),
            Link = Faker.Internet.Url(),
            PreparationTime = Faker.Random.Int(1),
            Servings = Faker.Random.Int(1),
            TelegramUserId = Faker.Random.Int(1),
            Title = Faker.Commerce.ProductName()
        };
    }
    
    public static Ingredient GetIngredientValid()
    {
        return new Ingredient()
        {
            Id = Faker.Random.Guid(),
            CreatedOn = Faker.Date.Past(),
            ModifiedOn = Faker.Date.Recent(),
            Name = Faker.Commerce.Product(),
            Quantity = Faker.Random.Int(1),
            RecipeId = Faker.Random.Guid(),
            Unit = UnitsOfMeasure.Gram
        };
    }
}