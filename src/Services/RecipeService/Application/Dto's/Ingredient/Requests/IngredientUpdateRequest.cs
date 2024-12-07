using Domain.Primitives;

namespace Application.Dto_s.Ingredient.Requests;

public record IngredientUpdateRequest(
    Guid Id, 
    Guid RecipeId, 
    string Name, 
    int? Quantity, 
    UnitsOfMeasure? Unit);