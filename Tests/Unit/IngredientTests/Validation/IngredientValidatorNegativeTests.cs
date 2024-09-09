using Bogus;
using Domain.Entities;
using Domain.Validations.Primitives;
using Domain.Validations.Validators;
using FluentValidation.TestHelper;

namespace Tests.Unit.IngredientTests.Validation;

public class IngredientValidatorNegativeTests
{
    private readonly IngredientValidator _ingredientValidator = new(nameof(Ingredient));
    private readonly Faker _faker = new Faker();
    
    [Fact]
    public void Name_ShouldHaveNullMessageValidationErrors_WhenNull()
    {
        var ingredient = new Ingredient
        {
            Name = null
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x=> x.Name)
            .WithErrorMessage(ExceptionMessages.NullException(nameof(Ingredient.Name)));
    }

    [Fact]
    public void Name_ShouldHaveEmptyMessageValidationErrors_WhenEmpty()
    {
        var ingredient = new Ingredient
        {
            Name = string.Empty
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage(ExceptionMessages.EmptyException(nameof(Ingredient.Name)));
    }
    
    [Fact]
    public void Name_ShouldHaveInvalidFormatMessageValidationErrors_WhenInvalidLength()
    {
        var ingredient = new Ingredient
        {
            Name = _faker.Lorem.Letter(251) 
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Ingredient.Name)));
    }

    [Fact]
    public void Quantity_ShouldHaveValidationErrors_WhenInvalid()
    {
        var ingredient = new Ingredient
        {
            Quantity = _faker.Random.Int(max:0)
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x => x.Quantity)
            .WithErrorMessage(ExceptionMessages.TooLowNumber(nameof(Ingredient.Quantity)));
    }
    
    [Fact]
    public void Unit_ShouldHaveValidationErrors_WhenInvalid()
    {
        var extremeValue = _faker.Random.Bool() ? int.MinValue : int.MaxValue;
        var ingredient = new Ingredient
        {
            Unit = (UnitsOfMeasure) extremeValue
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x => x.Unit)
            .WithErrorMessage(ExceptionMessages.InvalidEnumValue(nameof(Ingredient.Unit)));
    }

    [Fact]
    public void RecipeId_ShouldHaveNullMessageValidationErrors_WhenNull()
    {
        var ingredient = new Ingredient();
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x=> x.RecipeId);
    }

    [Fact]
    public void RecipeId_ShouldHaveEmptyMessageValidationErrors_WhenEmpty()
    {
        var ingredient = new Ingredient
        {
            RecipeId = Guid.Empty
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x => x.RecipeId)
            .WithErrorMessage(ExceptionMessages.EmptyException(nameof(Ingredient.RecipeId)));
    }
}