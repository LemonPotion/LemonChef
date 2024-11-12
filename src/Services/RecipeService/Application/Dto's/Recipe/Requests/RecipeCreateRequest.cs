namespace Application.Dto_s.Recipe.Requests;

public record RecipeCreateRequest(string Title, string? Link, int? PreparationTime, int? Servings, string Description);