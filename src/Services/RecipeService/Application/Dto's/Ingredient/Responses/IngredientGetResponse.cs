using Domain.Primitives;

namespace Application.Dto_s.Ingredient.Responses;

public record IngredientGetResponse(
    Guid Id, 
    Guid RecipeId, 
    string Name, 
    int? Quantity, 
    UnitsOfMeasure? Unit);