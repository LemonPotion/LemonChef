using Domain.Interfaces;
using Domain.Primitives;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class Ingredient : BaseEntity, ITrackable
{
    public string Name { get; set; }

    public int? Quantity { get; set; }

    public UnitsOfMeasure? Unit { get; set; }

    public Recipe Recipe { get; set; }
    public Guid RecipeId { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;

    public ICollection<IngredientFile>? Files { get; set; }

    public Ingredient()
    {
    }

    public Ingredient(string name, int? quantity, UnitsOfMeasure? unit, Guid recipeId)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
        RecipeId = recipeId;

        var validator = new IngredientValidator(nameof(Ingredient));
        validator.ValidateAndThrow(this);
    }
}