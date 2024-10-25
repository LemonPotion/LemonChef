using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class RecipeFileValidator : AbstractValidator<RecipeFile>
{
    public RecipeFileValidator(string paramName)
    {
        Include(new LemonChefFileValidator(nameof(RecipeFile)));
        
        RuleFor(param => param.RecipeId)
            .NotNullOrEmptyWithMessage(nameof(RecipeFile.RecipeId));
    }
}