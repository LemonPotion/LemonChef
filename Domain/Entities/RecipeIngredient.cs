using Domain.Validations.Primitives;

namespace Domain.Entities;

public class RecipeIngredient : BaseEntity
{
    public Recipe Recipe { get; set; }
    public Ingredient Ingredient { get; set; }
    public int? Quantity { get; set; }
    public Unit? Unit { get; set; }
}