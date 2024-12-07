using Domain.Entities.Base;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class IngredientFile : LemonChefFile
{
    public Guid IngredientId { get; set; }

    public Ingredient Ingredient { get; set; }

    public IngredientFile()
    {
    }

    public IngredientFile(Guid userId, Guid ingredientId, string googleDriveName) : base(userId, googleDriveName)
    {
        IngredientId = ingredientId;

        var validator = new IngredientFileValidator(nameof(IngredientFile));
        validator.ValidateAndThrow(this);
    }
}