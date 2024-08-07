using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class IngredientValidator :AbstractValidator<Ingredient>
{
    public IngredientValidator(string paramName)
    {
        RuleFor(param => param.Name)
            .NotNull().WithMessage(ExceptionMessages.NullException(paramName))
            .NotEmpty().WithMessage(ExceptionMessages.EmptyException(paramName));
        RuleFor(param => param.Quantity)
            .NotEmpty().When(param=> param.Quantity is not null).WithMessage(ExceptionMessages.EmptyException(paramName));
        RuleFor(param => param.Unit)
            .NotEmpty().When(param=> param.Quantity is not null).WithMessage(ExceptionMessages.EmptyException(paramName));
        RuleFor(param => param.CreationDate)
            .NotNull().WithMessage(ExceptionMessages.NullException(paramName))
            .NotEmpty().WithMessage(ExceptionMessages.EmptyException(paramName));
        RuleFor(param => param.UpdateTime)
            .NotNull().WithMessage(ExceptionMessages.NullException(paramName))
            .NotEmpty().WithMessage(ExceptionMessages.EmptyException(paramName));
    }
}