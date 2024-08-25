using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class IngredientValidator :AbstractValidator<Ingredient>
{
    public IngredientValidator(string paramName)
    {
        Include(new BaseEntityValidator<Ingredient>(paramName));
        RuleFor(param => param.Name)
            .NotNullOrEmptyWithMessage(paramName).Length(1,250);
    }
}