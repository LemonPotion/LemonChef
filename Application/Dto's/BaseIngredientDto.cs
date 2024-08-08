using Domain.Validations.Primitives;

namespace Application.Dto_s;

public class BaseIngredientDto
{
    public string Name { get; set; }
    public int? Quantity { get; set; }
    public Unit? Unit { get; set; }
}