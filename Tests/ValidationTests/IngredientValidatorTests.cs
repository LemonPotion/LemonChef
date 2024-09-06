using Domain.Entities;
using Domain.Validations.Primitives;
using Domain.Validations.Validators;
using FluentValidation.TestHelper;

namespace Tests.ValidationTests;

public class IngredientValidatorTests
{
    private readonly IngredientValidator _ingredientValidator = new(nameof(Ingredient));

    [Theory]
    [InlineData("Tomato")]
    [InlineData("Banana")]
    [InlineData("Calamansi")]
    public void Name_ShouldNotHaveValidationErrors_WhenValid(string name)
    {
        var ingredient = new Ingredient
        {
            Name = name
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldNotHaveValidationErrorFor(x=> x.Name);
    }

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
    
    [Theory]
    [MemberData(nameof(InvalidLengthNameData))]
    public void Name_ShouldHaveInvalidFormatMessageValidationErrors_WhenInvalidLength(string name)
    {
        var ingredient = new Ingredient
        {
            Name = name
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Ingredient.Name)));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(250)]
    public void Quantity_ShouldNotHaveValidationErrors_WhenValid(int quantity)
    {
        var ingredient = new Ingredient
        {
            Quantity = quantity
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldNotHaveValidationErrorFor(x=>x.Quantity);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Quantity_ShouldHaveValidationErrors_WhenInvalid(int quantity)
    {
        var ingredient = new Ingredient
        {
            Quantity = quantity
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x => x.Quantity)
            .WithErrorMessage(ExceptionMessages.TooLowNumber(nameof(Ingredient.Quantity)));
    }

    [Fact]
    public void Unit_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = new Ingredient
        {
            Unit = UnitsOfMeasure.Teaspoon
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldNotHaveValidationErrorFor(x => x.Unit);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(93)]
    public void Unit_ShouldHaveValidationErrors_WhenInvalid(int unit)
    {
        var ingredient = new Ingredient
        {
            Unit = (UnitsOfMeasure)unit 
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldHaveValidationErrorFor(x => x.Unit)
            .WithErrorMessage(ExceptionMessages.InvalidEnumValue(nameof(Ingredient.Unit)));
    }
    
    [Fact]
    public void RecipeId_ShouldNotHaveValidationErrors_WhenValid()
    {
        var ingredient = new Ingredient
        {
            RecipeId = Guid.NewGuid()
        };
        var result = _ingredientValidator.TestValidate(ingredient);
        result.ShouldNotHaveValidationErrorFor(x=> x.RecipeId);
    }

    [Fact]
    public void RecipeId_ShouldHaveNullMessageValidationErrors_WhenNull()
    {
        var ingredient = new Ingredient
        {

        };
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
    
    public static IEnumerable<object[]> InvalidLengthNameData =>
        new List<object[]>
        {
            new object[] { "N" },
            new object[] { new string('A', 251) }
        };
}