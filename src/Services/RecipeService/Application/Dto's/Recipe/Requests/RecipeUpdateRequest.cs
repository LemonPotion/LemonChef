namespace Application.Dto_s.Recipe.Requests;

public record RecipeUpdateRequest(
    Guid Id,
    string Title,
    string? Link,
    int? PreparationTime,
    int? Servings,
    string Description);