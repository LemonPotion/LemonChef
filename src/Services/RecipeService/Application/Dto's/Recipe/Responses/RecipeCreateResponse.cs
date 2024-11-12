using Application.Dto_s.Ingredient.Responses;

namespace Application.Dto_s.Recipe.Responses;

public record RecipeCreateResponse(
    Guid Id,
    string Title,
    string? Link,
    int? PreparationTime,
    int? Servings,
    string Description,
    Guid? UserId,
    ICollection<IngredientGetResponse>? Ingredients);