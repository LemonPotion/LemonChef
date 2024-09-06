using Domain.Entities;
using Domain.Validations.Primitives;
using Domain.Validations.Validators;
using FluentValidation.TestHelper;

namespace Tests.ValidationTests;

public class RecipeValidatorTests
{
    private readonly RecipeValidator _recipeValidator = new(nameof(Recipe));
    
    [Theory]
    [InlineData("Delicious Pie recipe")]
    [InlineData("Eating healthy 101")]
    public void Title_ShouldNotHaveValidationErrors_WhenValid(string title)
    {
        var recipe = new Recipe
        {
            Title = title
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.Title);
    }
    
    [Fact]
    public void Title_ShouldHaveNullMessageValidationErrors_WhenNull()
    {
        var recipe = new Recipe
        {
            Title = null
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(ExceptionMessages.NullException(nameof(Recipe.Title)));
    }
    
    [Fact]
    public void Title_ShouldHaveEmptyMessageValidationErrors_WhenEmpty()
    {
        var recipe = new Recipe
        {
            Title = string.Empty
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(ExceptionMessages.EmptyException(nameof(Recipe.Title)));
    }
    
    [Theory]
    [MemberData(nameof(InvalidLengthNameData))]
    public void Title_ShouldHaveInvalidFormatMessageValidationErrors_WhenInvalidLength(string title)
    {
        var recipe = new Recipe
        {
            Title = title
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Recipe.Title)));
    }
    
    [Theory]
    [InlineData("https://valid.url")]
    [InlineData("http://example.com")]
    public void Link_ShouldNotHaveValidationErrors_WhenValid(string link)
    {
        var recipe = new Recipe
        {
            Link = link
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.Link);
    }
    
    [Fact]
    public void Link_ShouldHaveValidationErrors_WhenInvalid()
    {
        var recipe = new Recipe
        {
            Link = "recipeLink"
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Link)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Recipe.Link)));
    }
    
    [Fact]
    public void Description_ShouldNotHaveValidationErrors_WhenValid()
    {
        var recipe = new Recipe
        {
            Description = "Description"
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }
    
    [Fact]
    public void Description_ShouldHaveNullMessageValidationErrors_WhenNull()
    {
        var recipe = new Recipe
        {
            Description = null
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage(ExceptionMessages.NullException(nameof(Recipe.Description)));
    }
    
    [Fact]
    public void Description_ShouldHaveEmptyMessageValidationErrors_WhenEmpty()
    {
        var recipe = new Recipe
        {
            Description = string.Empty
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage(ExceptionMessages.EmptyException(nameof(Recipe.Description)));
    }
    
    [Theory]
    [MemberData(nameof(InvalidLengthNameData))]
    public void Description_ShouldHaveInvalidFormatMessageValidationErrors_WhenInvalidLength(string description)
    {
        var recipe = new Recipe
        {
            Description = description
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Recipe.Description)));
    }
    public static IEnumerable<object[]> InvalidLengthNameData =>
        new List<object[]>
        {
            new object[] { "N" },
            new object[] { new string('A', 5001) }
        };
    
    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    public void Servings_ShouldNotHaveValidationErrors_WhenValid(int servings)
    {
        var recipe = new Recipe
        {
            Servings = servings
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.Servings);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Servings_ShouldHaveValidationErrors_WhenInvalid(int servings)
    {
        var recipe = new Recipe
        {
            Servings = servings
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.Servings)
            .WithErrorMessage(ExceptionMessages.TooLowNumber(nameof(Recipe.Servings)));
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(120)]
    public void PreparationTime_ShouldNotHaveValidationErrors_WhenValid(int preparationTime)
    {
        var recipe = new Recipe
        {
            PreparationTime = preparationTime
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.PreparationTime);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void PreparationTime_ShouldHaveValidationErrors_WhenInvalid(int preparationTime)
    {
        var recipe = new Recipe
        {
            PreparationTime = preparationTime
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.PreparationTime)
            .WithErrorMessage(ExceptionMessages.TooLowNumber(nameof(Recipe.PreparationTime)));
    }
    
    [Theory]
    [InlineData(12345)]
    [InlineData(67890)]
    public void TelegramUserId_ShouldNotHaveValidationErrors_WhenValid(int telegramUserId)
    {
        var recipe = new Recipe
        {
            TelegramUserId = telegramUserId
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldNotHaveValidationErrorFor(x => x.TelegramUserId);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void TelegramUserId_ShouldHaveValidationErrors_WhenInvalid(int telegramUserId)
    {
        var recipe = new Recipe
        {
            TelegramUserId = telegramUserId
        };
        var result = _recipeValidator.TestValidate(recipe);
        result.ShouldHaveValidationErrorFor(x => x.TelegramUserId)
            .WithErrorMessage(ExceptionMessages.InvalidFormat(nameof(Recipe.TelegramUserId)));
    }
}