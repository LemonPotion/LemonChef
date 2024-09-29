using Domain.Validations.Primitives;

namespace Application.Dto_s.Ingredient;

public class BaseIngredientDto
{
    public Guid RecipeId { get; set; }
    
    public string Name { get; set; }
    
    public int? Quantity { get; set; }
    
    public UnitsOfMeasure? Unit { get; set; }
}