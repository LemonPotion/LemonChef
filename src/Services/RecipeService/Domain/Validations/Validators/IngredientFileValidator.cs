using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class IngredientFileValidator : AbstractValidator<IngredientFile>
{
    public IngredientFileValidator(string paramName)
    {
        Include(new LemonChefFileValidator(nameof(IngredientFile)));

        RuleFor(param => param.IngredientId)
            .NotNullOrEmptyWithMessage(nameof(IngredientFile.IngredientId));
    }
}