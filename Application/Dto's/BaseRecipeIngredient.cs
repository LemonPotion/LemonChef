using Domain.Validations.Primitives;

namespace Application.Dto_s;

public class BaseRecipeIngredient
{
    public BaseRecipeDto Recipe { get; set; }
    
    public BaseIngredientDto Ingredient { get; set; }
    
    public int? Quantity { get; set; }
    
    public UnitsOfMeasure? Unit { get; set; }
}