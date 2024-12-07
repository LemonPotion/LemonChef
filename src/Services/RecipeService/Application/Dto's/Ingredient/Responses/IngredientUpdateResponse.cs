using Domain.Primitives;

namespace Application.Dto_s.Ingredient.Responses;

public record IngredientUpdateResponse(
    Guid Id, 
    Guid RecipeId, 
    string Name, 
    int? Quantity, 
    UnitsOfMeasure? Unit);