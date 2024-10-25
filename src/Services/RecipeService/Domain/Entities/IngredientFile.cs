using Domain.Entities.Base;
using Domain.Interfaces;
using Domain.Validations.Primitives;
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

    public IngredientFile(Guid userId, Guid ingredientId, string fileName, string filePath, FileFormats fileFormat, int fileSizeInBytes, long? duration) : base(userId, fileName, filePath, fileFormat, fileSizeInBytes, duration)
    {
        IngredientId = ingredientId;
        
        var validator = new IngredientFileValidator(nameof(IngredientFile));
        validator.ValidateAndThrow(this);
    }
}