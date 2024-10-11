using Domain.Entities.Base;
using Domain.Interfaces;
using Domain.Validations.Primitives;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class Ingredient : BaseEntity, ITrackable, IRateable
{
    public string Name { get; set; }

    public int? Quantity { get; set; }

    public UnitsOfMeasure? Unit { get; set; }

    public Recipe Recipe { get; set; }
    public Guid RecipeId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string CreatedBy { get; set; }

    public string ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public Ingredient()
    {
    }

    public Ingredient(Guid id, string name, int? quantity, UnitsOfMeasure? unit, Guid recipeId)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Unit = unit;
        RecipeId = recipeId;

        var validator = new IngredientValidator(nameof(Ingredient));
        validator.ValidateAndThrow(this);
    }

    public long ViewCount { get; set; }
    public long LikeCount { get; set; }
    public long CommentCount { get; set; }
    public long ShareCount { get; set; }
}