using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class RecipeLikeValidator : AbstractValidator<RecipeLike>
{
    public RecipeLikeValidator(string paramName)
    {
        Include(new LikeValidator(nameof(RecipeLike)));

        RuleFor(param => param.RecipeId)
            .NotNullOrEmptyWithMessage(nameof(RecipeLike.RecipeId));
    }
}