using Domain.Primitives;

namespace Application.Dto_s.Ingredient.Requests;

public record IngredientCreateRequest(
    Guid RecipeId, 
    string Name, 
    int? Quantity, 
    UnitsOfMeasure? Unit);