using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class RecipeIngredientValidator : AbstractValidator<RecipeIngredient>
{
    public RecipeIngredientValidator(string paramName)
    {
        Include(new BaseEntityValidator<RecipeIngredient>(paramName));

        RuleFor(param => param.Ingredient)
            .NotNullOrEmptyWithMessage(paramName);
        RuleFor(param => param.Recipe)
            .NotNullOrEmptyWithMessage(paramName);
        RuleFor(param => param.Unit)
            .NotNullOrEmptyWithMessage(paramName);
    }
}