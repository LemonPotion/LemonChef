using Bogus;
using Domain.Entities;
using Domain.Validations.Primitives;
using Domain.Validations.Validators;
using FluentValidation.TestHelper;
using Tests.Unit.Data;

namespace Tests.Unit.IngredientTests.Validation;

public class IngredientValidatorPositiveTests
{
    private readonly IngredientValidator _ingredientValidator = new(nameof(Ingredient));
    private readonly Faker _faker = new Faker();

    [Fact]
    public void Name_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = TestDataValidGenerator.GetIngredientValid();
        
        var result = _ingredientValidator.TestValidate(ingredient);
        
        result.ShouldNotHaveValidationErrorFor(x=> x.Name);
        
    }
    
    [Fact]
    public void Quantity_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = TestDataValidGenerator.GetIngredientValid();
        
        var result = _ingredientValidator.TestValidate(ingredient);
        
        result.ShouldNotHaveValidationErrorFor(x=>x.Quantity);
    }
    
    [Fact]
    public void Unit_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = TestDataValidGenerator.GetIngredientValid();
        
        var result = _ingredientValidator.TestValidate(ingredient);
        
        result.ShouldNotHaveValidationErrorFor(x => x.Unit);
    }
    
    [Fact]
    public void RecipeId_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = TestDataValidGenerator.GetIngredientValid();
        
        var result = _ingredientValidator.TestValidate(ingredient);
        
        result.ShouldNotHaveValidationErrorFor(x=> x.RecipeId);
    }
}