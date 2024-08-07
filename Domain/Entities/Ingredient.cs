using Domain.Validations.Primitives;

namespace Domain.Entities;

public class Ingredient : BaseEntity
{
    public string Name { get; set; }
    public int? Quantity { get; set; }
    public Unit? Unit { get; set; }
}