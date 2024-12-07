namespace Application.Dto_s.Recipe.Requests;

public record RecipeUpdateRequest(
    Guid Id,
    Guid UserId,
    string Title,
    string? Link,
    int? PreparationTime,
    int? Servings,
    string Description);