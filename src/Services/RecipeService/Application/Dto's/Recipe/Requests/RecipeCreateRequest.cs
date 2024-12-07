namespace Application.Dto_s.Recipe.Requests;

//TODO: ModifiedOn не меняется
public record RecipeCreateRequest(
    Guid UserId,
    string Title,
    string? Link,
    int? PreparationTime,
    int? Servings,
    string Description);