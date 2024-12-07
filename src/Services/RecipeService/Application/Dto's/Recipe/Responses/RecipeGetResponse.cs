using Application.Dto_s.Ingredient.Responses;

namespace Application.Dto_s.Recipe.Responses;

public record RecipeGetResponse(
    Guid Id,
    string Title,
    string? Link,
    int? PreparationTime,
    int? Servings,
    string Description,
    Guid UserId,
    long LikeCount,
    long ViewCount,
    ICollection<IngredientGetResponse>? Ingredients);