using Domain.Validations.Primitives;

namespace Application.Dto_s.Ingredient.Responses;

public record IngredientCreateResponse(Guid Id, Guid RecipeId, string Name, int? Quantity, UnitsOfMeasure? Unit);