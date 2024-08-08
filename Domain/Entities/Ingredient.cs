using Domain.Validations.Primitives;

namespace Domain.Entities;

public class Ingredient : BaseEntity
{
    public string Name { get; set; }
}