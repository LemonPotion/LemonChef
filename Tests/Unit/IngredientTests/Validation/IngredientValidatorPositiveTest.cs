using Bogus;
using Domain.Entities;
using Domain.Validations.Primitives;
using Domain.Validations.Validators;
using FluentValidation.TestHelper;

namespace Tests.Unit.IngredientTests.Validation;

public class IngredientValidatorPositiveTest
{
    private readonly IngredientValidator _ingredientValidator = new(nameof(Ingredient));
    private readonly Faker _faker = new Faker();

    [Fact]
    public void Name_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = new Ingredient
        {
            Name = _faker.Commerce.Product()
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldNotHaveValidationErrorFor(x=> x.Name);
    }
    
    [Fact]
    public void Quantity_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = new Ingredient
        {
            Quantity = _faker.Random.Int(1)
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldNotHaveValidationErrorFor(x=>x.Quantity);
    }
    
    [Fact]
    public void Unit_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = new Ingredient
        {
            Unit = UnitsOfMeasure.Gram
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldNotHaveValidationErrorFor(x => x.Unit);
    }
    
    [Fact]
    public void RecipeId_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = new Ingredient
        {
            RecipeId = _faker.Random.Guid()
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldNotHaveValidationErrorFor(x=> x.RecipeId);
    }
}