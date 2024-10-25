using Domain.Entities.Base;
using Domain.Interfaces;
using Domain.Validations.Primitives;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class RecipeFile : LemonChefFile
{
    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }

    public RecipeFile()
    {
        
    }

    public RecipeFile(Guid userId, Guid recipeId, string fileName, string filePath, FileFormats fileFormat, int fileSizeInBytes, long? duration) : base(userId, fileName, filePath, fileFormat, fileSizeInBytes, duration)
    {
        RecipeId = recipeId;
        
        var validator = new RecipeFileValidator(nameof(RecipeFile));
        validator.ValidateAndThrow(this);
    }
}