using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class RecipeValidator : AbstractValidator<Recipe>
{
    public RecipeValidator(string paramName)
    {
        RuleFor(param => param.Title)
            .NotNull().WithMessage(ExceptionMessages.NullException(paramName))
            .NotEmpty().WithMessage(ExceptionMessages.EmptyException(paramName));
        RuleFor(param => param.Link)
            .NotNull().WithMessage(ExceptionMessages.NullException(paramName))
            .NotEmpty().WithMessage(ExceptionMessages.EmptyException(paramName));
        RuleForEach(param => param.Ingredient)
            .NotNull().WithMessage(ExceptionMessages.NullException(paramName))
            .NotEmpty().WithMessage(ExceptionMessages.EmptyException(paramName));
        RuleFor(param => param.Hash)
            .NotNull().WithMessage(ExceptionMessages.NullException(paramName))
            .NotEmpty().WithMessage(ExceptionMessages.EmptyException(paramName));
        RuleFor(param=> param.Servings)
            .NotEmpty().When(param=> param.Servings is not null).WithMessage(ExceptionMessages.EmptyException(paramName));
        RuleFor(param=>param.PreparationTime)
            .NotEmpty().When(param=> param.PreparationTime is not null).WithMessage(ExceptionMessages.EmptyException(paramName));
    }
}