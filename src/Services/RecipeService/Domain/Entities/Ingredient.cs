using System.Text.Json.Serialization;
using Domain.Validations.Primitives;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class Ingredient : BaseEntity
{
    public string Name { get; set; }
    
    public int? Quantity { get; set; }
    
    public UnitsOfMeasure? Unit { get; set; }
    
    public Recipe Recipe { get; set; }
    public Guid RecipeId { get; set; }

    public Ingredient()
    {
        
    }
    public Ingredient(Guid id,string name, int? quantity, UnitsOfMeasure? unit, Guid recipeId)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Unit = unit;
        RecipeId = recipeId;

        var validator = new IngredientValidator(nameof(Ingredient));
        validator.ValidateAndThrow(this);
    }
    
}